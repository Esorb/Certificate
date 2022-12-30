using Esorb.Certificate.Basics;
using Esorb.Certificate.Model.Interfaces;

namespace Esorb.Certificate.Model
{
    internal class Comment : ViewModelBase, IValueInput
    {
        private long commentID;
        private long pupilID;
        private long certificateID;
        private long contentID;
        private string commentName;
        private string commentText;
        private int maxLength;
        public Comment()
        {
            commentName = "";
            commentText = "";
        }

        public long CommentID
        {
            get
            {
                return commentID;
            }
            set
            {
                commentID = value;
                OnPropertyChanged(nameof(CommentID));
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

        public string ValueName
        {
            get
            {
                return commentName;
            }
            set
            {
                commentName = value;
                OnPropertyChanged(nameof(ValueName));
            }
        }

        public string ValueString
        {
            get
            {
                return commentText;
            }
            set
            {
                commentText = value;
                OnPropertyChanged(nameof(ValueString));
            }
        }

        public int MaxLength
        {
            get
            {
                return maxLength;
            }
            set
            {
                maxLength = value;
                OnPropertyChanged(nameof(MaxLength));
            }
        }

    }
}
