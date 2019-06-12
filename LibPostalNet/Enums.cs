using System;

namespace LibPostalNet
{
    [Flags]
    public enum AddressComponents : int
    {
        NONE = 0,
        ANY = (1 << 0),
        NAME = (1 << 1),
        HOUSE_NUMBER = (1 << 2),
        STREET = (1 << 3),
        UNIT = (1 << 4),
        LEVEL = (1 << 5),
        STAIRCASE = (1 << 6),
        ENTRANCE = (1 << 7),

        CATEGORY = (1 << 8),
        NEAR = (1 << 9),

        TOPONYM = (1 << 13),
        POSTAL_CODE = (1 << 14),
        PO_BOX = (1 << 15),
        ALL = ((1 << 16) - 1)
    }

    [Flags]
    public enum NormalizeString : long
    {
        LATIN_ASCII = (1 << 0),
        TRANSLITERATE = (1 << 1),
        STRIP_ACCENTS = (1 << 2),
        DECOMPOSE = (1 << 3),
        LOWERCASE = (1 << 4),
        TRIM = (1 << 5),
        REPLACE_HYPHENS = (1 << 6),
        COMPOSE = (1 << 7),
        SIMPLE_LATIN_ASCII = (1 << 8),
        REPLACE_NUMEX = (1 << 9),

        DEFAULT = (LATIN_ASCII | COMPOSE | TRIM | REPLACE_HYPHENS | STRIP_ACCENTS | LOWERCASE)
    }

    public enum NormalizeToken : long
    {
        REPLACE_HYPHENS = (1 << 0),
        DELETE_HYPHENS = (1 << 1),
        DELETE_FINAL_PERIOD = (1 << 2),
        DELETE_ACRONYM_PERIODS = (1 << 3),
        DROP_ENGLISH_POSSESSIVES = (1 << 4),
        DELETE_OTHER_APOSTROPHE = (1 << 5),
        SPLIT_ALPHA_FROM_NUMERIC = (1 << 6),
        REPLACE_DIGITS = (1 << 7),
        REPLACE_NUMERIC_TOKEN_LETTERS = (1 << 8),
        REPLACE_NUMERIC_HYPHENS = (1 << 9),

        DEFAULT = (REPLACE_HYPHENS | DELETE_FINAL_PERIOD | DELETE_ACRONYM_PERIODS | DROP_ENGLISH_POSSESSIVES | DELETE_OTHER_APOSTROPHE),
        DROP_PERIODS = (DELETE_FINAL_PERIOD | DELETE_ACRONYM_PERIODS),
        DEFAULT_NUMERIC = (DEFAULT | SPLIT_ALPHA_FROM_NUMERIC)
    }

    public enum TokenType : long
    {
        END = 0,                   // Null byte

        // Word types
        WORD = 1,                  // Any letter-only word (includes all unicode letters)
        ABBREVIATION = 2,          // Loose abbreviations (roughly anything containing a "." as we don't care about sentences in addresses)
        IDEOGRAPHIC_CHAR = 3,      // For languages that don't separate on whitespace (e.g. Chinese, Japanese, Korean), separate by character
        HANGUL_SYLLABLE = 4,       // Hangul syllable sequences which contain more than one codepoint
        ACRONYM = 5,               // Specifically things like U.N. where we may delete internal periods

        PHRASE = 10,               // Not part of the first stage tokenizer, but may be used after phrase parsing

        // Special tokens
        EMAIL = 20,                // Make sure emails are tokenized altogether
        URL = 21,                  // Make sure urls are tokenized altogether
        US_PHONE = 22,             // US phone number (with or without country code)
        INTL_PHONE = 23,           // A non-US phone number (must have country code)

        // Numbers and numeric types
        NUMERIC = 50,              // Any sequence containing a digit
        ORDINAL = 51,              // 1st, 2nd, 1er, 1 etc.
        ROMAN_NUMERAL = 52,        // II, III, VI, etc.
        IDEOGRAPHIC_NUMBER = 53,   // All numeric ideographic characters, includes e.g. Han numbers and chars like "²"

        // Punctuation types, may separate a phrase
        PERIOD = 100,
        EXCLAMATION = 101,
        QUESTION_MARK = 102,
        COMMA = 103,
        COLON = 104,
        SEMICOLON = 105,
        PLUS = 106,
        AMPERSAND = 107,
        AT_SIGN = 108,
        POUND = 109,
        ELLIPSIS = 110,
        DASH = 111,
        BREAKING_DASH = 112,
        HYPHEN = 113,
        PUNCT_OPEN = 114,
        PUNCT_CLOSE = 115,
        DOUBLE_QUOTE = 119,
        SINGLE_QUOTE = 120,
        OPEN_QUOTE = 121,
        CLOSE_QUOTE = 122,
        SLASH = 124,
        BACKSLASH = 125,
        GREATER_THAN = 126,
        LESS_THAN = 127,

        // Non-letters and whitespace
        OTHER = 200,
        WHITESPACE = 300,
        NEWLINE = 301,

        INVALID_CHAR = 500
    }

    public enum DuplicateStatus : int
    {
        NULL = -1,
        NON_DUPLICATE = 0,
        POSSIBLE_DUPLICATE_NEEDS_REVIEW = 3,
        LIKELY_DUPLICATE = 6,
        EXACT_DUPLICATE = 9,
    }
}
