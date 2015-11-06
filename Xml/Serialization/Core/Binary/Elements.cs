namespace Olan.Xml.Serialization.Core.Binary {
    /// <summary>
    ///   These elements are used during the binary serialization. They should be unique from SubElements and Attributes.
    /// </summary>
    public static class Elements {
        #region Fields

        ///<summary>
        ///</summary>
        public const byte Collection = 1;

        ///<summary>
        ///</summary>
        public const byte CollectionWithId = 10;

        ///<summary>
        ///</summary>
        public const byte ComplexObject = 2;

        ///<summary>
        /// For binary compatibility reason extra type-id: same as ComplexObjectWith, but contains 
        ///</summary>
        public const byte ComplexObjectWithId = 8;

        ///<summary>
        ///</summary>
        public const byte Dictionary = 3;

        ///<summary>
        ///</summary>
        public const byte DictionaryWithId = 11;

        ///<summary>
        ///</summary>
        public const byte MultiArray = 4;

        ///<summary>
        ///</summary>
        public const byte MultiArrayWithId = 13;

        ///<summary>
        ///</summary>
        public const byte Null = 5;

        ///<summary>
        /// reference to previosly serialized  ComplexObjectWithId
        ///</summary>
        public const byte Reference = 9;

        ///<summary>
        ///</summary>
        public const byte SimpleObject = 6;

        ///<summary>
        ///</summary>
        public const byte SingleArray = 7;

        ///<summary>
        ///</summary>
        public const byte SingleArrayWithId = 12;

        #endregion
        #region Methods

        ///<summary>
        ///</summary>
        ///<param name="elementId"></param>
        ///<returns></returns>
        public static bool IsElementWithId(byte elementId) {
            if (elementId == ComplexObjectWithId) {
                return true;
            }
            if (elementId == CollectionWithId) {
                return true;
            }
            if (elementId == DictionaryWithId) {
                return true;
            }
            if (elementId == SingleArrayWithId) {
                return true;
            }
            if (elementId == MultiArrayWithId) {
                return true;
            }
            return false;
        }

        #endregion
    }

    /// <summary>
    ///   These elements are used during the binary serialization. They should be unique from Elements and Attributes.
    /// </summary>
    public static class SubElements {
        #region Fields

        ///<summary>
        ///</summary>
        public const byte Dimension = 51;

        ///<summary>
        ///</summary>
        public const byte Dimensions = 52;

        ///<summary>
        ///</summary>
        public const byte Eof = 255;

        ///<summary>
        ///</summary>
        public const byte Item = 53;

        ///<summary>
        ///</summary>
        public const byte Items = 54;

        ///<summary>
        ///</summary>
        public const byte Properties = 55;

        ///<summary>
        ///</summary>
        public const byte Unknown = 254;

        #endregion
    }

    /// <summary>
    ///   These attributes are used during the binary serialization. They should be unique from Elements and SubElements.
    /// </summary>
    public class Attributes {
        #region Fields

        ///<summary>
        ///</summary>
        public const byte DimensionCount = 101;

        ///<summary>
        ///</summary>
        public const byte ElementType = 102;

        ///<summary>
        ///</summary>
        public const byte Indexes = 103;

        ///<summary>
        ///</summary>
        public const byte KeyType = 104;

        ///<summary>
        ///</summary>
        public const byte Length = 105;

        ///<summary>
        ///</summary>
        public const byte LowerBound = 106;

        ///<summary>
        ///</summary>
        public const byte Name = 107;

        ///<summary>
        ///</summary>
        public const byte Type = 108;

        ///<summary>
        ///</summary>
        public const byte Value = 109;

        ///<summary>
        ///</summary>
        public const byte ValueType = 110;

        #endregion
    }

    /// <summary>
    ///   How many bytes occupies a number value
    /// </summary>
    public static class NumberSize {
        #region Fields

        ///<summary>
        ///  serializes as 1 byte
        ///</summary>
        public const byte B1 = 1;

        ///<summary>
        ///  serializes as 2 bytes
        ///</summary>
        public const byte B2 = 2;

        ///<summary>
        ///  serializes as 4 bytes
        ///</summary>
        public const byte B4 = 4;
        ///<summary>
        ///  is zero
        ///</summary>
        public const byte Zero = 0;

        #endregion
        #region Methods

        /// <summary>
        ///   Gives the least required byte amount to store the number
        /// </summary>
        /// <param name = "value"></param>
        /// <returns></returns>
        public static byte GetNumberSize(int value) {
            if (value == 0) {
                return Zero;
            }
            if (value > short.MaxValue || value < short.MinValue) {
                return B4;
            }
            if (value < byte.MinValue || value > byte.MaxValue) {
                return B2;
            }
            return B1;
        }

        #endregion
    }
}