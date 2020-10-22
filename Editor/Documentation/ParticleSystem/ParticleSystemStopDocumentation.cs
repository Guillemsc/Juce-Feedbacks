﻿using System;
using UnityEditor;
using UnityEngine;

namespace Juce.Feedbacks
{
    public class ParticleSystemStopDocumentation : IFeedbackDocumentation
    {
        public Type FeedbackType => typeof(ParticleSystemStopFeedback);

        public void DrawDocumentation()
        {
            GUILayout.Label("Stops the target ParticleSystem", EditorStyles.wordWrappedLabel);

            EditorGUILayout.Space(2);

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Label("- Target: ParticleSystem that is going to be stoped", EditorStyles.wordWrappedLabel);
            }

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Label("- With Children: stop all child ParticleSystem aswell", EditorStyles.wordWrappedLabel);
                GUILayout.Label("- Stop Behavior: stop emitting or stop emitting and clear the system.", EditorStyles.wordWrappedLabel);
            }

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GenericsDocumentation.DelayDocumentation();
            }

            EditorGUILayout.Space(2);

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Label("Sequencing:");
                GenericsDocumentation.SameTimeSequencingDocumentation();
            }
        }
    }
}