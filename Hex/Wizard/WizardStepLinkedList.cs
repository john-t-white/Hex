using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hex.Wizard
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "Not intended to be serialized" )]
	public class WizardStepLinkedList
		: LinkedList<WizardStep>, IWizardStepCollection
	{
		private WizardStep _currentStep;

		public WizardStepLinkedList( IEnumerable<WizardStep> wizardSteps )
			: base( wizardSteps )
		{
			this._currentStep = this.First.Value;
		}

		public WizardStepLinkedList( IEnumerable<WizardStep> wizardSteps, WizardStep currentStep )
			: base( wizardSteps )
		{
			if( currentStep == null )
			{
				throw new ArgumentNullException( "currentStep" );
			}

			if( !this.Contains( currentStep ) )
			{
				throw new ArgumentException( ExceptionMessages.CURRENT_WIZARD_STEP_DOES_NOT_EXIST_IN_COLLECTION );
			}

			this._currentStep = currentStep;
		}

		public WizardStep CurrentStep
		{
			get
			{
				return this._currentStep;
			}
			set
			{
				if( value == null )
				{
					throw new ArgumentNullException();
				}

				if( !this.Contains( value ) )
				{
					throw new ArgumentException( ExceptionMessages.CURRENT_WIZARD_STEP_DOES_NOT_EXIST_IN_COLLECTION );
				}

				this._currentStep = value;
			}
		}

		public WizardStep FirstStep
		{
			get
			{
				return this.First.Value;
			}
		}

		public WizardStep LastStep
		{
			get
			{
				return this.Last.Value;
			}
		}

		public WizardStep NextStep
		{
			get
			{
				LinkedListNode<WizardStep> wizardStepNode = this.Find( this._currentStep ).Next;
				if( wizardStepNode != null )
				{
					return wizardStepNode.Value;
				}

				return null;
			}
		}

		public WizardStep PreviousStep
		{
			get
			{
				LinkedListNode<WizardStep> wizardStepNode = this.Find( this._currentStep ).Previous;
				if( wizardStepNode != null )
				{
					return wizardStepNode.Value;
				}

				return null;
			}
		}

		public bool HasNextStep()
		{
			return this.NextStep != null;
		}

		public bool HasPreviousStep()
		{
			return this.PreviousStep != null;
		}

		public WizardStep MoveToNextStep()
		{
			if( !this.HasNextStep() )
			{
				throw new InvalidOperationException( ExceptionMessages.NEXT_WIZARD_STEP_NOT_FOUND );
			}

			return this._currentStep = this.NextStep;
		}

		public WizardStep MoveToPreviousStep()
		{
			if( !this.HasPreviousStep() )
			{
				throw new InvalidOperationException( ExceptionMessages.PREVIOUS_WIZARD_STEP_NOT_FOUND );
			}

			return this._currentStep = this.PreviousStep;
		}
	}
}
