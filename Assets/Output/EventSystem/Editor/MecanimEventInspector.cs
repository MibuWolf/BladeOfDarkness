using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;


[CustomEditor(typeof(MecanimEventData))]
public class MecanimEventInspector : Editor {
	// Controller -> Layer -> State
	private Dictionary<UnityEditor.Animations.AnimatorController, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> data;
	
	void OnEnable() {
		LoadData();
		
		MecanimEventEditor.eventInspector = this;	
	}
	
	void OnDisable() {
		//SaveData();
		MecanimEventEditor.eventInspector = null;
		
		OnPreviewDisable();
	}
	
	public override void OnInspectorGUI ()
	{
		if (GUILayout.Button("Open Event Editor")) {
			MecanimEventEditor editor = EditorWindow.GetWindow<MecanimEventEditor>();
			editor.TargetController = serializedObject.FindProperty("lastEdit").objectReferenceValue;
		}
		
		if (previewedMotion != null && previewedMotion is UnityEditor.Animations.BlendTree && avatarPreview != null) {
			EditorGUILayout.Separator();
			GUILayout.Label("BlendTree Parameter(s)", GUILayout.ExpandWidth(true));
			
			UnityEditor.Animations.BlendTree bt = previewedMotion as UnityEditor.Animations.BlendTree;
			
			for (int i = 0; i < bt.GetRecursiveBlendParamCount(); i++) {
				float min = bt.GetRecursiveBlendParamMin(i);
				float max = bt.GetRecursiveBlendParamMax(i);
				
				string paramName = bt.GetRecursiveBlendParam(i);
				float value = Mathf.Clamp(avatarPreview.Animator.GetFloat(paramName), min, max);
				value = EditorGUILayout.Slider(paramName, value, min, max);
				avatarPreview.Animator.SetFloat(paramName, value);
			}
		}
	}
	
	public UnityEditor.Animations.AnimatorController[] GetControllers() {
		return new List<UnityEditor.Animations.AnimatorController>(data.Keys).ToArray();
	}
	
	public void AddController(UnityEditor.Animations.AnimatorController controller) {
		if (!data.ContainsKey(controller)) {
			data[controller] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
		}
	}
	
	public MecanimEvent[] GetEvents(UnityEditor.Animations.AnimatorController controller, int layer, int stateNameHash) {
		try {
			return data[controller][layer][stateNameHash].ToArray();
		}
		catch {
			return new MecanimEvent[0];
		}
	}
	
	public void SetEvents(UnityEditor.Animations.AnimatorController controller, int layer, int stateNameHash, MecanimEvent[] events) {
		if (!data.ContainsKey(controller)) {
			data[controller] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
		}
		
		if (!data[controller].ContainsKey(layer)) {
			data[controller][layer] = new Dictionary<int, List<MecanimEvent>>();
		}
		
		if (!data[controller][layer].ContainsKey(stateNameHash)) {
			data[controller][layer][stateNameHash] = new List<MecanimEvent>();
		}
		
		data[controller][layer][stateNameHash] = new List<MecanimEvent>(events);
	}
	
	public void InsertEventsCopy(UnityEditor.Animations.AnimatorController controller, int layer, int stateNameHash, MecanimEvent[] events) {
		
		List<MecanimEvent> allEvents = new List<MecanimEvent>(GetEvents(controller, layer, stateNameHash));
		
		foreach (MecanimEvent e in events) {
			allEvents.Add(new MecanimEvent(e));
		}
		
		SetEvents(controller, layer, stateNameHash, allEvents.ToArray());
	}
	
	public Dictionary<int, Dictionary<int, MecanimEvent[]>> GetEvents(UnityEditor.Animations.AnimatorController controller) {
		try {
			
			Dictionary<int, Dictionary<int, MecanimEvent[]>> events = new Dictionary<int, Dictionary<int, MecanimEvent[]>>();
			
			foreach(int layer in data[controller].Keys) {
				
				events[layer] = new Dictionary<int, MecanimEvent[]>();
				
				foreach (int state in data[controller][layer].Keys) {
					
					List<MecanimEvent> stateEvents = new List<MecanimEvent>();
					
					foreach (MecanimEvent elem in data[controller][layer][state]) {
						stateEvents.Add(new MecanimEvent(elem));
					}
					
					events[layer][state] = stateEvents.ToArray();
				}
			}
			
			return events;
			
		}
		catch {
			return new Dictionary<int, Dictionary<int, MecanimEvent[]>>();
		}
	}
	
	public void InsertControllerEventsCopy(UnityEditor.Animations.AnimatorController controller, Dictionary<int, Dictionary<int, MecanimEvent[]>> events) {
		
		try {
			
			foreach (int layer in events.Keys) {
				
				foreach (int state in events[layer].Keys) {
					
 					InsertEventsCopy(controller, layer, state, events[layer][state]);
					
				}
			}
			
		}
		catch {
			
		}
		
		return;
	}
	
	private Motion previewedMotion;
	private AvatarPreviewWrapper avatarPreview;
	private UnityEditor.Animations.AnimatorStateMachine stateMachine;
	private UnityEditor.Animations.AnimatorState state;
	private UnityEditor.Animations.AnimatorController controller;
	
	private bool PrevIKOnFeet = false;
	//
	
	public void SetPreviewMotion(Motion motion) {
		if (previewedMotion == motion)
			return;
		
		previewedMotion = motion;
		
		ClearStateMachine();
		
		if (avatarPreview == null)
		{
			avatarPreview = new AvatarPreviewWrapper(null, previewedMotion);
			avatarPreview.OnAvatarChangeFunc = this.OnPreviewAvatarChanged;
			PrevIKOnFeet = avatarPreview.IKOnFeet;
		}
		
		if (motion != null)
			CreateStateMachine();
		
		Repaint();
	}
	
	public float GetPlaybackTime() {
		if (avatarPreview != null)
			return avatarPreview.timeControl.normalizedTime;
		else
			return 0;
	}
	
	public void SetPlaybackTime(float time) {
		
		if (avatarPreview != null) {
			avatarPreview.timeControl.nextCurrentTime = Mathf.Lerp(avatarPreview.timeControl.startTime,
																avatarPreview.timeControl.stopTime,
																time);
		}
		Repaint();
	}
	
	public bool IsPlaying() {
		return avatarPreview.timeControl.playing;
	}
	
	public void StopPlaying() {
		avatarPreview.timeControl.playing = false;
	}
	
	public override bool HasPreviewGUI ()
	{
		//return previewedMotion != null;
		return true;
	}
	
	public override void OnPreviewSettings ()
	{
		if (avatarPreview != null)
			avatarPreview.DoPreviewSettings();
	}
	
	public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
	{
		if (avatarPreview == null || previewedMotion == null)
			return;
		
		UpdateAvatarState();
		avatarPreview.DoAvatarPreview(r, background);
	}
	
	private void OnPreviewDisable() {
		previewedMotion = null;
		
		ClearStateMachine();
		if (avatarPreview != null) {
			avatarPreview.OnDestroy();
			avatarPreview = null;
		}
	}
	
	private void OnPreviewAvatarChanged()
	{
		ResetStateMachine();
	}
	
	private void CreateStateMachine() {
		if (avatarPreview == null || avatarPreview.Animator == null)
			return;
		
		if (controller == null)
		{
			controller = new UnityEditor.Animations.AnimatorController();
			controller.AddLayer("preview");
			controller.hideFlags = HideFlags.DontSave;
			
			//stateMachine = controller.GetLayer(0).stateMachine;
			CreateParameters();
			
			state = stateMachine.AddState("preview");
			state.SetMotion(previewedMotion);
			state.iKOnFeet = avatarPreview.IKOnFeet;
			state.hideFlags = HideFlags.DontSave;
			
			UnityEditor.Animations.AnimatorController.SetAnimatorController(avatarPreview.Animator, controller);
		}
		
		//if (UnityEditor.Animations.AnimatorController.GetEffectiveAnimatorController(avatarPreview.Animator) != this.controller)
		//{
		//	UnityEditor.Animations.AnimatorController.SetAnimatorController(avatarPreview.Animator, this.controller);
		//}
	}
	
	private void CreateParameters()
	{
        int parameterCount = 0;// controller.parameterCount;
        for (int i = 0; i < parameterCount; i++)
		{
			controller.RemoveParameter(0);
		}
		
		if (previewedMotion is UnityEditor.Animations.BlendTree)
		{
			UnityEditor.Animations.BlendTree blendTree = previewedMotion as UnityEditor.Animations.BlendTree;
			
			for (int j = 0; j < blendTree.GetRecursiveBlendParamCount(); j++)
			{
				//controller.AddParameter(blendTree.GetRecursiveBlendParam(j), AnimatorControllerParameterType.Float);
			}
		}
	}
	
	private void ClearStateMachine()
	{
		if (avatarPreview != null && avatarPreview.Animator != null)
		{
			UnityEditor.Animations.AnimatorController.SetAnimatorController(avatarPreview.Animator, null);
		}
		Object.DestroyImmediate(this.controller);
		Object.DestroyImmediate(this.stateMachine);
		Object.DestroyImmediate(this.state);
		stateMachine = null;
		controller = null;
		state = null;
	}
	
	public void ResetStateMachine()
	{
		ClearStateMachine();
		CreateStateMachine();
	}
	
	private void UpdateAvatarState()
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}
		
		Animator animator = avatarPreview.Animator;
		if (animator)
		{
			if (PrevIKOnFeet != avatarPreview.IKOnFeet)
			{
				PrevIKOnFeet = avatarPreview.IKOnFeet;
				Vector3 rootPosition = avatarPreview.Animator.rootPosition;
				Quaternion rootRotation = avatarPreview.Animator.rootRotation;
				ResetStateMachine();
				avatarPreview.Animator.UpdateWrapper(avatarPreview.timeControl.currentTime);
				avatarPreview.Animator.UpdateWrapper(0f);
				avatarPreview.Animator.rootPosition = rootPosition;
				avatarPreview.Animator.rootRotation = rootRotation;
			}

			avatarPreview.timeControl.loop = true;
			float num = 1f;
			float num2 = 0f;
			if (animator.layerCount > 0)
			{
				AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
				num = currentAnimatorStateInfo.length;
				num2 = currentAnimatorStateInfo.normalizedTime;
			}
			
			avatarPreview.timeControl.startTime = 0f;
			avatarPreview.timeControl.stopTime = num;
			avatarPreview.timeControl.Update();
			
			float num3 = this.avatarPreview.timeControl.deltaTime;
			if (!previewedMotion.isLooping)
			{
				if (num2 >= 1f)
				{
					num3 -= num;
				}
				else
				{
					if (num2 < 0f)
					{
						num3 += num;
					}
				}
			}
			animator.UpdateWrapper(num3);
		}
	}
	
	private void LoadData() {
		
		MecanimEventData dataSource = target as MecanimEventData;
		
		data = new Dictionary<UnityEditor.Animations.AnimatorController, Dictionary<int, Dictionary<int, List<MecanimEvent>>>>();
		
		if (dataSource.data == null || dataSource.data.Length == 0)
			return;
		
		foreach(MecanimEventDataEntry entry in dataSource.data) {
			
			UnityEditor.Animations.AnimatorController animatorController = entry.animatorController as UnityEditor.Animations.AnimatorController;
			
			if (animatorController == null)
				return;
			
			if (!data.ContainsKey(animatorController))
				data[animatorController] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
			
			if (!data[animatorController].ContainsKey(entry.layer)) {
				data[animatorController][entry.layer] = new Dictionary<int, List<MecanimEvent>>();
			}
			
			List<MecanimEvent> events = new List<MecanimEvent>();
			
			if (entry.events != null) {
				foreach (MecanimEvent e in entry.events) {
					
					events.Add(new MecanimEvent(e));
					
				}
			}
			
			data[animatorController][entry.layer][entry.stateNameHash] = events;
			
		}
	}
	
	public void SaveData() {
		
		MecanimEventData targetData = target as MecanimEventData;
		Undo.RecordObject(target, "Mecanim Event Data");
		
		List<MecanimEventDataEntry> entries = new List<MecanimEventDataEntry>();

		foreach(UnityEditor.Animations.AnimatorController controller in data.Keys) {
			foreach(int layer in data[controller].Keys) {
				foreach(int stateNameHash in data[controller][layer].Keys) {
					
					if (data[controller][layer][stateNameHash].Count == 0)
						continue;
					
					if (!IsValidState(controller.GetInstanceID(), layer, stateNameHash)) {
						continue;
					}
					
					MecanimEventDataEntry entry = new MecanimEventDataEntry();
					entry.animatorController = controller;
					entry.layer = layer;
					entry.stateNameHash = stateNameHash;
					entry.events = data[controller][layer][stateNameHash].ToArray();;
					
					entries.Add(entry);
				}
			}
		}
		
		targetData.data = entries.ToArray();
		
		EditorUtility.SetDirty(target);
	}
	
	public void SaveLastEditController(UnityEngine.Object controller) {
		serializedObject.FindProperty("lastEdit").objectReferenceValue = controller;;
	}
	
	private bool IsValidState(int controllerId, int layer, int stateNameHash) {
		if (!IsValidControllerId(controllerId))
			return false;
		
		if (!IsValidLayer(controllerId, layer))
			return false;
		
		UnityEditor.Animations.AnimatorController controller = EditorUtility.InstanceIDToObject(controllerId) as UnityEditor.Animations.AnimatorController;
        //UnityEditor.Animations.AnimatorStateMachine sm = controller.GetLayer(layer).stateMachine;

        return false;// FindStateRecursively(sm, stateNameHash);
	}
	
		
	private bool IsValidControllerId(int controllerId) {
		UnityEditor.Animations.AnimatorController controller = EditorUtility.InstanceIDToObject(controllerId) as UnityEditor.Animations.AnimatorController;
		
		if (controller == null)
			return false;
		
		return true;
	}
	
	private bool IsValidLayer(int controllerId, int layer) {
		UnityEditor.Animations.AnimatorController controller = EditorUtility.InstanceIDToObject(controllerId) as UnityEditor.Animations.AnimatorController;
		
		if (controller == null)
			return false;

        return false;
	}
	
	private bool FindStateRecursively(UnityEditor.Animations.AnimatorStateMachine stateMachine, int nameHash) {

		
		return false;
	}
}