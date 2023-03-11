using Esorb.Certificate.App.Model.Interfaces;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class SubjectDecisionInput : PersistentObject, IValueInput
{
    private long subjectDecisionID;
    private long inputContextID;
    private string subjectDecisionName = string.Empty;
    private string subjectDecisionValue = string.Empty;
    private long subjectAlternativeGroupID;
    private SubjectAlternativeGroup? subjectAlternativeGroup;
    private InputContext? context;

    public long SubjectDecisionID
    {
        get
        {
            return subjectDecisionID;
        }
        set
        {
            subjectDecisionID = value;
        }
    }

    public long InputContextID
    {
        get => inputContextID;
        set
        {
            inputContextID = value;
        }
    }

    public string ValueName
    {
        get => subjectDecisionName;
        set
        {
            subjectDecisionName = value;
        }
    }

    public string ValueString
    {
        get => subjectDecisionValue;
        set
        {
            subjectDecisionValue = value;
        }
    }

    public long SubjectAlternativeGroupID
    {
        get => subjectAlternativeGroupID;
        set
        {
            subjectAlternativeGroupID = value;
        }
    }

    public SubjectAlternativeGroup? SubjectAlternativeGroup
    {
        get => subjectAlternativeGroup;
        set
        {
            subjectAlternativeGroup = value;
        }
    }
    public InputContext? Context
    {
        get => context;
        set
        {
            context = value;
        }
    }

    InputContext? IValueInput.Context { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
