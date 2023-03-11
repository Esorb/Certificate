using Esorb.Certificate.App.Basics;
using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class InputContext : ViewModelBase
{
    private long inputContextID;
    private long valueInputID;
    private long pupilID;
    private long certificateID;
    private long contentID;
    private Pupil? pupil;
    private Certificate? certificate;
    private IContent? content;

    public long InputContextID
    {
        get
        {
            return inputContextID;
        }
        set
        {
            inputContextID = value;
            OnPropertyChanged(nameof(InputContextID));
        }
    }

    public long ValueInputID
    {
        get
        {
            return valueInputID;
        }
        set
        {
            valueInputID = value;
            OnPropertyChanged(nameof(ValueInputID));
        }
    }

    public long PupilID
    {
        get
        {
            return pupilID;
        }
        set
        {
            pupilID = value;
            OnPropertyChanged(nameof(PupilID));
        }
    }

    public long CertificateID
    {
        get
        {
            return certificateID;
        }
        set
        {
            certificateID = value;
            OnPropertyChanged(nameof(CertificateID));
        }
    }

    public long ContentID
    {
        get
        {
            return contentID;
        }
        set
        {
            contentID = value;
            OnPropertyChanged(nameof(ContentID));
        }
    }

    public Pupil? Pupil
    {
        get
        {
            return pupil;
        }
        set
        {
            pupil = value;
            OnPropertyChanged(nameof(Pupil));
        }
    }

    public Certificate? Certificate
    {
        get
        {
            return certificate;
        }
        set
        {
            certificate = value;
            OnPropertyChanged(nameof(Certificate));
        }
    }

    public IContent? Content
    {
        get
        {
            return content;
        }
        set
        {
            content = value;
            OnPropertyChanged(nameof(Content));
        }
    }

}
