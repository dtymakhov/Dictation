﻿namespace Dictation.Extensions
{
    using Windows.UI;
    using Windows.UI.Xaml.Controls;

    public static class RichEditBoxExtension
    {
        public static void SetRtf(this RichEditBox richEditBox, string rtf)
        {
            richEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, rtf);
        }

        public static string GetRtf(this RichEditBox richEditBox)
        {
            string rtf;
            richEditBox.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out rtf);
            return rtf;
        }

        public static void ClearUndo(this RichEditBox richEditBox)
        {
            uint limit = richEditBox.Document.UndoLimit;
            richEditBox.Document.UndoLimit = 0;
            richEditBox.Document.UndoLimit = limit;
        }

        public static bool CanRedo(this RichEditBox richEditBox)
        {
            return richEditBox.Document.CanRedo();
        }

        public static bool Redo(this RichEditBox richEditBox)
        {
            if (richEditBox.Document.CanRedo())
            {
                richEditBox.Document.Redo();
            }

            return CanRedo(richEditBox);
        }

        public static bool CanUndo(this RichEditBox richEditBox)
        {
            return richEditBox.Document.CanUndo();
        }

        public static bool Undo(this RichEditBox richEditBox)
        {
            if (richEditBox.Document.CanUndo())
            {
                richEditBox.Document.Undo();
            }

            return CanUndo(richEditBox);
        }

        public static bool IsBold(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Bold == Windows.UI.Text.FormatEffect.On;
        }

        public static bool Bold(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Bold = Windows.UI.Text.FormatEffect.Toggle;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsBold(richEditBox);
        }

        public static bool IsItalic(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Italic == Windows.UI.Text.FormatEffect.On;
        }

        public static bool Italic(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Italic = Windows.UI.Text.FormatEffect.Toggle;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsItalic(richEditBox);
        }

        public static bool IsUnderline(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Underline != Windows.UI.Text.UnderlineType.None;
        }

        public static bool Underline(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Underline = IsUnderline(richEditBox) ? Windows.UI.Text.UnderlineType.None : Windows.UI.Text.UnderlineType.Single;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsUnderline(richEditBox);
        }

        public static bool IsStrikethrough(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Strikethrough == Windows.UI.Text.FormatEffect.On;
        }

        public static bool Strikethrough(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Strikethrough = Windows.UI.Text.FormatEffect.Toggle;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsStrikethrough(richEditBox);
        }

        public static bool IsSuperscript(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Superscript == Windows.UI.Text.FormatEffect.On;
        }

        public static bool Superscript(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Superscript = Windows.UI.Text.FormatEffect.Toggle;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsSuperscript(richEditBox);
        }

        public static bool IsSubscript(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Subscript == Windows.UI.Text.FormatEffect.On;
        }

        public static bool Subscript(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Subscript = Windows.UI.Text.FormatEffect.Toggle;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsSubscript(richEditBox);
        }

        public static bool IsAlignLeft(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.ParagraphFormat.Alignment == Windows.UI.Text.ParagraphAlignment.Left;
        }

        public static bool AlignLeft(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.ParagraphFormat.Alignment = IsAlignLeft(richEditBox) ? Windows.UI.Text.ParagraphAlignment.Undefined : Windows.UI.Text.ParagraphAlignment.Left;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsAlignLeft(richEditBox);
        }

        public static bool IsAlignRight(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.ParagraphFormat.Alignment == Windows.UI.Text.ParagraphAlignment.Right;
        }

        public static bool AlignRight(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.ParagraphFormat.Alignment = IsAlignRight(richEditBox) ? Windows.UI.Text.ParagraphAlignment.Undefined : Windows.UI.Text.ParagraphAlignment.Right;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsAlignRight(richEditBox);
        }

        public static bool IsAlignCenter(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.ParagraphFormat.Alignment == Windows.UI.Text.ParagraphAlignment.Center;
        }

        public static bool AlignCenter(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.ParagraphFormat.Alignment = IsAlignCenter(richEditBox) ? Windows.UI.Text.ParagraphAlignment.Undefined : Windows.UI.Text.ParagraphAlignment.Center;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsAlignCenter(richEditBox);
        }

        public static bool IsJustify(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.ParagraphFormat.Alignment == Windows.UI.Text.ParagraphAlignment.Justify;
        }

        public static bool Justify(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.ParagraphFormat.Alignment = IsJustify(richEditBox) ? Windows.UI.Text.ParagraphAlignment.Undefined : Windows.UI.Text.ParagraphAlignment.Justify;
            if (focus)
            {
                Focus(richEditBox);
            }

            return IsJustify(richEditBox);
        }

        public static bool HasBullets(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.ParagraphFormat.ListType == Windows.UI.Text.MarkerType.Bullet;
        }

        public static bool Bullets(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.ParagraphFormat.ListType = HasBullets(richEditBox) ? Windows.UI.Text.MarkerType.None : Windows.UI.Text.MarkerType.Bullet;
            richEditBox.Document.Selection.ParagraphFormat.ListStyle = Windows.UI.Text.MarkerStyle.Plain;
            if (focus)
            {
                Focus(richEditBox);
            }

            return HasBullets(richEditBox);
        }

        public static bool HasNumbers(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.ParagraphFormat.ListType == Windows.UI.Text.MarkerType.Arabic;
        }

        public static bool Numbers(this RichEditBox richEditBox, bool focus = true)
        {
            richEditBox.Document.Selection.ParagraphFormat.ListType = HasNumbers(richEditBox) ? Windows.UI.Text.MarkerType.None : Windows.UI.Text.MarkerType.Arabic;
            richEditBox.Document.Selection.ParagraphFormat.ListStart = 1;
            richEditBox.Document.Selection.ParagraphFormat.ListStyle = Windows.UI.Text.MarkerStyle.Parenthesis;
            if (focus)
            {
                Focus(richEditBox);
            }

            return HasNumbers(richEditBox);
        }

        public static float GetSize(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Size;
        }

        public static float SetSize(this RichEditBox richEditBox, float size, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Size = size;
            if (focus)
            {
                Focus(richEditBox);
            }

            return GetSize(richEditBox);
        }

        public static Color GetForeground(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.ForegroundColor;
        }

        public static Color SetForeground(this RichEditBox richEditBox, Color color, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.ForegroundColor = color;
            if (focus)
            {
                Focus(richEditBox);
            }

            return GetForeground(richEditBox);
        }

        public static Color GetBackground(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.BackgroundColor;
        }

        public static Color SetBackground(this RichEditBox richEditBox, Color color, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.BackgroundColor = color;
            if (focus)
            {
                Focus(richEditBox);
            }

            return GetBackground(richEditBox);
        }

        public static string GetFont(this RichEditBox richEditBox)
        {
            return richEditBox.Document.Selection.CharacterFormat.Name;
        }

        public static string SetFont(this RichEditBox richEditBox, string font, bool focus = true)
        {
            richEditBox.Document.Selection.CharacterFormat.Name = font;
            if (focus)
            {
                Focus(richEditBox);
            }

            return GetFont(richEditBox);
        }

        public static void Focus(this RichEditBox richEditBox)
        {
            richEditBox.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }
    }
}