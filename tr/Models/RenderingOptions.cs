using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace tr.Models
{
    [MessageContract]
    public class RenderingOptions
    {
        public RenderingOptions()
        {
        }

        /// <summary>
        /// Content - data source that will be binded onto the report
        /// </summary>
        [MessageBodyMember]
        public string Content
        {
            get; set;
        }

        /// <summary>
        /// Input format of the <see cref="Content"/>
        /// </summary>
        [MessageBodyMember]
        public InputFormat Format
        {
            get; set;
        }

        /// <summary>
        /// The template that will be used for creating the desired output
        /// </summary>
        [MessageBodyMember]
        public string Template
        {
            get; set;
        }

        /// <summary>
        /// The desired output format of the template
        /// </summary>
        [MessageBodyMember]
        public OutputFormat OutputFormat
        {
            get; set;
        }
    }

    [DataContract()]
    public enum OutputFormat
    {
        [EnumMember]
        PDF,

        [EnumMember]
        WordML,

        [EnumMember]
        HTML,

        [EnumMember]
        JPEG,

        [EnumMember]
        PNG,

        [EnumMember]
        DOCX
    }

    [DataContract()]
    public enum InputFormat
    {
        [EnumMember]
        XSLFO,

        [EnumMember]
        SVG,

        [EnumMember]
        XML,

        [EnumMember]
        WordML,

        [EnumMember]
        DocX,

        [EnumMember]
        PDF,

        [EnumMember]
        HTML
    }

    [MessageContract]
    public class TemplateResponse
    {
        [MessageBodyMember]
        public byte[] Response { get; set; }
    }
}