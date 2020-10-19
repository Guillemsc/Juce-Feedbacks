﻿using System;
using UnityEngine;
using Juce.Tween;
using System.Collections.Generic;

namespace Juce.Feedbacks
{
    [FeedbackIdentifier("Interactable", "UI/")]
    public class UIInteractableFeedback : Feedback
    {
        [Header(FeedbackSectionsUtils.TargetSection)]
        [SerializeField] private GameObject target = default;

        [Header(FeedbackSectionsUtils.ValuesSection)]
        [SerializeField] private bool interactable = default;
        [SerializeField] private bool blocksRaycasts = default;

        [Header(FeedbackSectionsUtils.TimingSection)]
        [SerializeField] [Min(0)] private float delay = default;

        public override bool GetFeedbackErrors(out string errors)
        {
            if (target == null)
            {
                errors = ErrorUtils.TargetNullErrorMessage;
                return true;
            }

            errors = "";
            return false;
        }

        public override string GetFeedbackTargetInfo()
        {
            return target != null ? target.name : string.Empty;
        }

        public override void GetFeedbackInfo(ref List<string> infoList)
        {
            InfoUtils.GetTimingInfo(ref infoList, delay);
            InfoUtils.GetInteractableInfo(ref infoList, interactable, blocksRaycasts);
        }

        public override ExecuteResult OnExecute(FlowContext context, SequenceTween sequenceTween)
        {
            CanvasGroup canvasGroup = target.GetOrAddComponent<CanvasGroup>();

            Tween.Tween delayTween = null;

            if (delay > 0)
            {
                delayTween = new WaitTimeTween(delay);
                sequenceTween.Append(delayTween);
            }

            sequenceTween.AppendCallback(() =>
            {
                canvasGroup.interactable = interactable;
                canvasGroup.blocksRaycasts = blocksRaycasts;
            });

            ExecuteResult result = new ExecuteResult();
            result.DelayTween = delayTween;

            return result;
        }
    }
}