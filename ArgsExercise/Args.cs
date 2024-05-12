using System;
using System.Collections.Generic;

namespace ArgsExercise
{
    public class Args
    {
        private string schema;
        private string[] args;
        private bool valid = true;
        private ISet<char> unexpectedArguments = new SortedSet<char>();
        private IDictionary<char, bool> booleanArgs = new Dictionary<char, bool>();
        private IDictionary<char, string> stringArgs = new Dictionary<char, string>();
        private IDictionary<char, int> intArgs = new Dictionary<char, int>();
        private ISet<char> argsFound = new HashSet<char>();
        private int currentArgument;
        private char errorArgumentId = '\0';
        private string errorParameter = "TILT";
        private ErrorCode errorCode = ErrorCode.OK;

        private enum ErrorCode
        {
            OK,
            MISSING_STRING,
            MISSING_INTEGER,
            INVALID_INTEGER,
            UNEXPECTED_ARGUMENT,
        }

        public Args(string schema, string[] args)
        {
            this.schema = schema;
            this.args = args;
            valid = this.Parse();
        }

        private bool Parse()
        {
            if (this.schema.Length == 0 && args.Length == 0)
            {
                return true;
            }
            this.ParseSchema();
            try
            {
                this.ParseArgument();
            }
            catch (ArgumentException)
            {
            }
            return this.valid;
        }

        private bool ParseSchema()
        {
            foreach (string elem in this.schema.Split(","))
            {
                elem.Length > 0
                {
                    string trimmedElem = elem.Trim();
                    this.ParseSchemaElement(trimmedElem);
                }
            }
            return true;
        }

        private void ParseSchemaElement(string elem)
        {
            char elemId = elem[0];
            string elemTail = elem.Substring(1);
            this.ValidateSchemaElementId(elemId);
            if (this.IsBooleanSchemaElement(elemTail))
            {
                this.ParseBooleanSchemaElement(elemId);
            }
            else if (this.IsStringSchemaElement(elemTail))
            {
                this.ParseStringSchemaElement(elemId);
            }
            else if (this.IsIntegerSchemaElement(elemTail))
            {
                this.ParseIntegerSchemaElement(elemId);
            }
            else
            {
                throw new Exception();
            }
        }

        private void ValidateSchemaElementId(char elemId)
        {
            if 
        }
        private class ArgumentException : Exception
        {
        }
    }
}