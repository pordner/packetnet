namespace PacketDotNet.Ieee80211
{
    /// <summary>
    /// The PPI Capture Info field has been assigned a PPI field type but currently has no defined
    /// field body.
    /// </summary>
    public class PpiCaptureInfo : PpiFields
    {
        /// <summary>
        /// Gets the field bytes. This doesn't include the PPI field header.
        /// </summary>
        /// <value>
        /// The bytes.
        /// </value>
        public override byte[] Bytes => new byte[0];

        /// <summary>Type of the field</summary>
        public override PpiFieldType FieldType => PpiFieldType.PpiCaptureInfo;

        /// <summary>
        /// Gets the length of the field data.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public override int Length => 0;
    }
}