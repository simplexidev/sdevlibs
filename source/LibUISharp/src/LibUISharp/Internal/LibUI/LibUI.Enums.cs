using System;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        public enum uiForEach : uint
        {
            uiForEachContinue,
            uiForEachStop
        }

        public enum uiWindowResizeEdge : uint
        {
            uiWindowResizeEdgeLeft,
            uiWindowResizeEdgeTop,
            uiWindowResizeEdgeRight,
            uiWindowResizeEdgeBottom,
            uiWindowResizeEdgeTopLeft,
            uiWindowResizeEdgeTopRight,
            uiWindowResizeEdgeBottomLeft,
            uiWindowResizeEdgeBottomRight
        }

        public enum uiDrawBrushType : uint
        {
            uiDrawBrushTypeSolid,
            uiDrawBrushTypeLinearGradient,
            uiDrawBrushTypeRadialGradient,
            uiDrawBrushTypeImage
        }

        public enum uiDrawLineCap : uint
        {
            uiDrawLineCapFlat,
            uiDrawLineCapRound,
            uiDrawLineCapSquare,
        }

        public enum uiDrawLineJoin : uint
        {
            uiDrawLineJoinMiter,
            uiDrawLineJoinRound,
            uiDrawLineJoinBevel
        }

        public enum uiDrawFillMode : uint
        {
            uiDrawFillModeWinding,
            uiDrawFillModeAlternate
        }

        public enum uiAttributeType : uint
        {
            uiAttributeTypeFamily,
            uiAttributeTypeSize,
            uiAttributeTypeWeight,
            uiAttributeTypeItalic,
            uiAttributeTypeStretch,
            uiAttributeTypeColor,
            uiAttributeTypeBackground,
            uiAttributeTypeUnderline,
            uiAttributeTypeUnderlineColor,
            uiAttributeTypeFeatures
        }

        public enum uiTextWeight : uint
        {
            uiTextWeightMinimum = 0,
            uiTextWeightThin = 100,
            uiTextWeightUltraLight = 200,
            uiTextWeightLight = 300,
            uiTextWeightBook = 350,
            uiTextWeightNormal = 400,
            uiTextWeightMedium = 500,
            uiTextWeightSemiBold = 600,
            uiTextWeightBold = 700,
            uiTextWeightUltraBold = 800,
            uiTextWeightHeavy = 900,
            uiTextWeightUltraHeavy = 950,
            uiTextWeightMaximum = 1000
        }

        public enum uiTextItalic : uint
        {
            uiTextItalicNormal,
            uiTextItalicOblique,
            uiTextItalicItalic
        }

        public enum uiTextStretch : uint
        {
            uiTextStretchUltraCondensed,
            uiTextStretchExtraCondensed,
            uiTextStretchCondensed,
            uiTextStretchSemiCondensed,
            uiTextStretchNormal,
            uiTextStretchSemiExpanded,
            uiTextStretchExpanded,
            uiTextStretchExtraExpanded,
            uiTextStretchUltraExpanded
        }

        public enum uiUnderline : uint
        {
            uiUnderlineNone,
            uiUnderlineSingle,
            uiUnderlineDouble,
            uiUnderlineSuggestion, // wavy or dotted underlines used for spelling/grammar checkers
        }

        public enum uiUnderlineColor : uint
        {
            uiUnderlineColorCustom,
            uiUnderlineColorSpelling,
            uiUnderlineColorGrammar,
            uiUnderlineColorAuxiliary, // for instance, the color used by smart replacements on macOS or in Microsoft Office
        }

        public enum uiDrawTextAlign : uint
        {
            uiDrawTextAlignLeft,
            uiDrawTextAlignCenter,
            uiDrawTextAlignRight
        }

        [Flags]
        public enum uiModifiers : uint
        {
            uiModifierCtrl = 1 << 0,
            uiModifierAlt = 1 << 1,
            uiModifierShift = 1 << 2,
            uiModifierSuper = 1 << 3
        }

        // uiExtKey => LibUISharp.Drawing.ExtensionKey
        public enum uiExtKey : uint
        {
            uiExtKeyEscape = 1,
            uiExtKeyInsert, // equivalent to "Help" on Apple keyboards
            uiExtKeyDelete,
            uiExtKeyHome,
            uiExtKeyEnd,
            uiExtKeyPageUp,
            uiExtKeyPageDown,
            uiExtKeyUp,
            uiExtKeyDown,
            uiExtKeyLeft,
            uiExtKeyRight,
            uiExtKeyF1, // F1..F12 are guaranteed to be consecutive
            uiExtKeyF2,
            uiExtKeyF3,
            uiExtKeyF4,
            uiExtKeyF5,
            uiExtKeyF6,
            uiExtKeyF7,
            uiExtKeyF8,
            uiExtKeyF9,
            uiExtKeyF10,
            uiExtKeyF11,
            uiExtKeyF12,
            uiExtKeyN0, // numpad keys; independent of Num Lock state
            uiExtKeyN1, // N0..N9 are guaranteed to be consecutive
            uiExtKeyN2,
            uiExtKeyN3,
            uiExtKeyN4,
            uiExtKeyN5,
            uiExtKeyN6,
            uiExtKeyN7,
            uiExtKeyN8,
            uiExtKeyN9,
            uiExtKeyNDot,
            uiExtKeyNEnter,
            uiExtKeyNAdd,
            uiExtKeyNSubtract,
            uiExtKeyNMultiply,
            uiExtKeyNDivide
        }

        public enum uiAlign : uint
        {
            uiAlignFill,
            uiAlignStart,
            uiAlignCenter,
            uiAlignEnd
        }

        public enum uiAt : uint
        {
            uiAtLeading,
            uiAtTop,
            uiAtTrailing,
            uiAtBottom
        }
    }
}