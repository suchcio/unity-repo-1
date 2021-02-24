#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
/// <summary>
/// https://answers.unity.com/questions/1537920/copy-reference-from-one-component-to-another-deriv.html?childToView=1537964#answer-1537964
/// </summary>
public static class ComponentUtil
{
    static SerializedObject source;
    [MenuItem("CONTEXT/Component/CopySerialized")]
    public static void CopySerializedFromBase(MenuCommand command)
    { source = new SerializedObject(command.context); }
    [MenuItem("CONTEXT/Component/PasteSerialized")]
    public static void PasteSerializedFromBase(MenuCommand command)
    {
        SerializedObject dest = new SerializedObject(command.context);
        SerializedProperty prop_iterator = source.GetIterator();
        //jump into serialized object, this will skip script type so that we dont override the destination component's type
        if (prop_iterator.NextVisible(true))
        {
            while (prop_iterator.NextVisible(true)) //itterate through all serializedProperties
            {
                //try obtaining the property in destination component
                SerializedProperty prop_element = dest.FindProperty(prop_iterator.name);

                //validate that the properties are present in both components, and that they're the same type
                if (prop_element != null && prop_element.propertyType == prop_iterator.propertyType)
                {
                    //copy value from source to destination component
                    dest.CopyFromSerializedProperty(prop_iterator);
                }
            }
        }
        dest.ApplyModifiedProperties();
    }
}
#endif