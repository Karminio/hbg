using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class MessageObj
    {
        private MessageTypeEnum _type;

        public MessageTypeEnum Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _summary;

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Buttons to be shown in the popup
        /// </summary>
        private MessageButtonsEnum _buttons;

        public MessageButtonsEnum Buttons
        {
            get { return _buttons; }
            set { _buttons = value; }
        }
    }

    public enum MessageTypeEnum
    {
        Info = 30,
        OperationDenied = 10,
        Error = 10,
    }

    public enum MessageButtonsEnum
    {
        OK,
        YesNo,
        OKCancel,
        YesNoCancel,
    }
}
