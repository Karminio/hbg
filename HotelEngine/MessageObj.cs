using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEngine
{
    public class MessageObj
    {
        private MessageTypeEnum m_type;

        public MessageTypeEnum Type
        {
            get { return m_type; }
            set { m_type = value; }
        }
        private string m_summary;

        public string Summary
        {
            get { return m_summary; }
            set { m_summary = value; }
        }
        private string m_description;

        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
        /// <summary>
        /// Buttons to be shown in the popup
        /// </summary>
        private MessageButtonsEnum m_buttons;

        public MessageButtonsEnum Buttons
        {
            get { return m_buttons; }
            set { m_buttons = value; }
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
