using Esorb.Certificate.Basics;
using Esorb.Certificate.Model.Interfaces;
using Esorb.School_Certificate.Model;

namespace Esorb.Certificate.Model.ValueInputs
{
    public class CommentInput : ViewModelBase, IValueInput
    {
        private long commentID;
        private long inputContextID;
        private string commentName;
        private string commentText;
        private int maxLength;
        private InputContext? context;

        public CommentInput()
        {
            commentName = string.Empty;
            commentText = string.Empty;
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

        public InputContext? Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
                OnPropertyChanged(nameof(Context));
            }
        }

    }
}
