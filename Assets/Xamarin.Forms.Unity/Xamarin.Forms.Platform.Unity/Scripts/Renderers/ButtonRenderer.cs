﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Xamarin.Forms.Platform.Unity
{
	public class ButtonRenderer : ViewRenderer<Button, UnityEngine.UI.Button>
	{
		/*-----------------------------------------------------------------*/
		#region Field

		LabelRenderer _labelRenderer;

		#endregion

		/*-----------------------------------------------------------------*/
		#region MonoBehavior

		protected override void Awake()
		{
			base.Awake();

			var button = Component;
			if (button != null)
			{
				button.OnClickAsObservable()
					.Subscribe(_ => (Element as IButtonController)?.SendClicked())
					.AddTo(this);
			}
		}

		#endregion
	}
}