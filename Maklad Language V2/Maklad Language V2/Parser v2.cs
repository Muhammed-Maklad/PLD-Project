
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Collections.Generic;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_MINUSMINUS           =  4, // '--'
        SYMBOL_EXCLAMEQ             =  5, // '!='
        SYMBOL_PERCENT              =  6, // '%'
        SYMBOL_LPAREN               =  7, // '('
        SYMBOL_RPAREN               =  8, // ')'
        SYMBOL_TIMES                =  9, // '*'
        SYMBOL_TIMESEQ              = 10, // '*='
        SYMBOL_COMMA                = 11, // ','
        SYMBOL_DOT                  = 12, // '.'
        SYMBOL_DIV                  = 13, // '/'
        SYMBOL_DIVEQ                = 14, // '/='
        SYMBOL_COLON                = 15, // ':'
        SYMBOL_LBRACKET             = 16, // '['
        SYMBOL_RBRACKET             = 17, // ']'
        SYMBOL_CARET                = 18, // '^'
        SYMBOL_LBRACE               = 19, // '{'
        SYMBOL_RBRACE               = 20, // '}'
        SYMBOL_PLUS                 = 21, // '+'
        SYMBOL_PLUSTIMES            = 22, // '+*'
        SYMBOL_PLUSPLUS             = 23, // '++'
        SYMBOL_PLUSEQ               = 24, // '+='
        SYMBOL_LT                   = 25, // '<'
        SYMBOL_EQ                   = 26, // '='
        SYMBOL_MINUSEQ              = 27, // '-='
        SYMBOL_EQEQ                 = 28, // '=='
        SYMBOL_GT                   = 29, // '>'
        SYMBOL_CATCH                = 30, // catch
        SYMBOL_CLASS                = 31, // class
        SYMBOL_COM                  = 32, // com
        SYMBOL_DIGIT                = 33, // digit
        SYMBOL_DO                   = 34, // do
        SYMBOL_ELSE                 = 35, // else
        SYMBOL_END                  = 36, // end
        SYMBOL_FLOAT                = 37, // float
        SYMBOL_FOR                  = 38, // for
        SYMBOL_FUNC                 = 39, // func
        SYMBOL_ID                   = 40, // Id
        SYMBOL_IF                   = 41, // if
        SYMBOL_INHERITS             = 42, // inherits
        SYMBOL_INT                  = 43, // int
        SYMBOL_RETURN               = 44, // return
        SYMBOL_STRING               = 45, // string
        SYMBOL_TO                   = 46, // to
        SYMBOL_TRY                  = 47, // try
        SYMBOL_WHILE                = 48, // while
        SYMBOL_WRITE                = 49, // write
        SYMBOL_ACCESS_CLASSFUNCTION = 50, // <access_classFunction>
        SYMBOL_ARGUMENTS            = 51, // <arguments>
        SYMBOL_ASSIGN               = 52, // <assign>
        SYMBOL_CALL_FUN             = 53, // <call_fun>
        SYMBOL_CLASS2               = 54, // <class>
        SYMBOL_CLASS_BODY           = 55, // <class_body>
        SYMBOL_CLASS_MEMBER         = 56, // <class_member>
        SYMBOL_CLASS_MEMBERS        = 57, // <class_members>
        SYMBOL_CLASS_OBJECT         = 58, // <class_object>
        SYMBOL_COMMENT_STMT         = 59, // <comment_stmt>
        SYMBOL_COND                 = 60, // <cond>
        SYMBOL_DATA_TYPE            = 61, // <data_type>
        SYMBOL_DICTIONARY           = 62, // <dictionary>
        SYMBOL_DIGIT2               = 63, // <digit>
        SYMBOL_DO_WHILE             = 64, // <do_while>
        SYMBOL_ELEMENT              = 65, // <element>
        SYMBOL_ELEMENTS             = 66, // <elements>
        SYMBOL_EXPRES               = 67, // <expres>
        SYMBOL_FACTOR               = 68, // <factor>
        SYMBOL_FOR_STMT             = 69, // <for_stmt>
        SYMBOL_FUNCTION             = 70, // <function>
        SYMBOL_GO                   = 71, // <Go>
        SYMBOL_IF_STMT              = 72, // <if_stmt>
        SYMBOL_INHERITANCE          = 73, // <Inheritance>
        SYMBOL_KEY                  = 74, // <key>
        SYMBOL_KEY_VALUE            = 75, // <key_value>
        SYMBOL_KEYS_VALUES          = 76, // <keys_values>
        SYMBOL_LIST                 = 77, // <list>
        SYMBOL_OP                   = 78, // <op>
        SYMBOL_PARAM                = 79, // <param>
        SYMBOL_PARAMETERS           = 80, // <parameters>
        SYMBOL_PRINT                = 81, // <print>
        SYMBOL_PRINT_ARGUMENTS      = 82, // <print_arguments>
        SYMBOL_RETURN_STMT          = 83, // <return_stmt>
        SYMBOL_STATEMENT            = 84, // <statement>
        SYMBOL_STEP                 = 85, // <step>
        SYMBOL_STMT_LIST            = 86, // <stmt_list>
        SYMBOL_TERM                 = 87, // <term>
        SYMBOL_TRY_CATCH            = 88, // <try_catch>
        SYMBOL_VALUE                = 89, // <value>
        SYMBOL_WHILE_STMT           = 90  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_GO                                                                                  =  0, // <Go> ::= <stmt_list>
        RULE_STMT_LIST                                                                           =  1, // <stmt_list> ::= <statement>
        RULE_STMT_LIST2                                                                          =  2, // <stmt_list> ::= <statement> <stmt_list>
        RULE_STATEMENT                                                                           =  3, // <statement> ::= <assign>
        RULE_STATEMENT2                                                                          =  4, // <statement> ::= <if_stmt>
        RULE_STATEMENT3                                                                          =  5, // <statement> ::= <for_stmt>
        RULE_STATEMENT4                                                                          =  6, // <statement> ::= <while_stmt>
        RULE_STATEMENT5                                                                          =  7, // <statement> ::= <do_while>
        RULE_STATEMENT6                                                                          =  8, // <statement> ::= <function>
        RULE_STATEMENT7                                                                          =  9, // <statement> ::= <return_stmt>
        RULE_STATEMENT8                                                                          = 10, // <statement> ::= <comment_stmt>
        RULE_STATEMENT9                                                                          = 11, // <statement> ::= <call_fun>
        RULE_STATEMENT10                                                                         = 12, // <statement> ::= <dictionary>
        RULE_STATEMENT11                                                                         = 13, // <statement> ::= <list>
        RULE_STATEMENT12                                                                         = 14, // <statement> ::= <try_catch>
        RULE_STATEMENT13                                                                         = 15, // <statement> ::= <class>
        RULE_STATEMENT14                                                                         = 16, // <statement> ::= <class_object>
        RULE_STATEMENT15                                                                         = 17, // <statement> ::= <access_classFunction>
        RULE_STATEMENT16                                                                         = 18, // <statement> ::= <print>
        RULE_COMMENT_STMT_COM                                                                    = 19, // <comment_stmt> ::= com
        RULE_ASSIGN_ID_EQ                                                                        = 20, // <assign> ::= <data_type> Id '=' <expres>
        RULE_DATA_TYPE_INT                                                                       = 21, // <data_type> ::= int
        RULE_DATA_TYPE_FLOAT                                                                     = 22, // <data_type> ::= float
        RULE_DATA_TYPE_STRING                                                                    = 23, // <data_type> ::= string
        RULE_EXPRES_PLUS                                                                         = 24, // <expres> ::= <term> '+' <expres>
        RULE_EXPRES_MINUS                                                                        = 25, // <expres> ::= <term> '-' <expres>
        RULE_EXPRES                                                                              = 26, // <expres> ::= <term>
        RULE_TERM_TIMES                                                                          = 27, // <term> ::= <factor> '*' <factor>
        RULE_TERM_DIV                                                                            = 28, // <term> ::= <factor> '/' <factor>
        RULE_TERM_PERCENT                                                                        = 29, // <term> ::= <factor> '%' <factor>
        RULE_TERM                                                                                = 30, // <term> ::= <factor>
        RULE_FACTOR_ID                                                                           = 31, // <factor> ::= Id
        RULE_FACTOR                                                                              = 32, // <factor> ::= <digit>
        RULE_FACTOR_CARET                                                                        = 33, // <factor> ::= <digit> '^' <digit>
        RULE_FACTOR_LPAREN_RPAREN                                                                = 34, // <factor> ::= '(' <expres> ')'
        RULE_DIGIT_DIGIT                                                                         = 35, // <digit> ::= digit
        RULE_FOR_STMT_FOR_LPAREN_TO_COMMA_RPAREN_COLON_LBRACE_RBRACE                             = 36, // <for_stmt> ::= for '(' <assign> to <assign> ',' <step> ')' ':' '{' <stmt_list> '}'
        RULE_STEP_MINUSMINUS_ID                                                                  = 37, // <step> ::= '--' Id
        RULE_STEP_ID_MINUSMINUS                                                                  = 38, // <step> ::= Id '--'
        RULE_STEP_PLUSPLUS_ID                                                                    = 39, // <step> ::= '++' Id
        RULE_STEP_ID_PLUSPLUS                                                                    = 40, // <step> ::= Id '++'
        RULE_STEP_ID_EQ_ID_PLUS                                                                  = 41, // <step> ::= Id '=' Id '+' <digit>
        RULE_STEP_ID_EQ_ID_MINUS                                                                 = 42, // <step> ::= Id '=' Id '-' <digit>
        RULE_STEP_ID_PLUSEQ                                                                      = 43, // <step> ::= Id '+=' <digit>
        RULE_STEP_ID_MINUSEQ                                                                     = 44, // <step> ::= Id '-=' <digit>
        RULE_STEP_ID_EQ_ID_PLUSTIMES                                                             = 45, // <step> ::= Id '=' Id '+*' <digit>
        RULE_STEP_ID_EQ_ID_DIV                                                                   = 46, // <step> ::= Id '=' Id '/' <digit>
        RULE_STEP_ID_TIMESEQ                                                                     = 47, // <step> ::= Id '*=' <digit>
        RULE_STEP_ID_DIVEQ                                                                       = 48, // <step> ::= Id '/=' <digit>
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_LBRACE_RBRACE                                        = 49, // <if_stmt> ::= if '(' <cond> ')' ':' '{' <stmt_list> '}'
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_LBRACE_RBRACE_ELSE_LBRACE_RBRACE                     = 50, // <if_stmt> ::= if '(' <cond> ')' ':' '{' <stmt_list> '}' else '{' <stmt_list> '}'
        RULE_COND                                                                                = 51, // <cond> ::= <expres> <op> <expres>
        RULE_OP_LT                                                                               = 52, // <op> ::= '<'
        RULE_OP_GT                                                                               = 53, // <op> ::= '>'
        RULE_OP_EQEQ                                                                             = 54, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                                                         = 55, // <op> ::= '!='
        RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_COLON_LBRACE_RBRACE                                  = 56, // <while_stmt> ::= while '(' <cond> ')' ':' '{' <stmt_list> '}'
        RULE_DO_WHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN                                       = 57, // <do_while> ::= do '{' <stmt_list> '}' while '(' <cond> ')'
        RULE_FUNCTION_FUNC_ID_LPAREN_RPAREN_COLON_LBRACE_RBRACE                                  = 58, // <function> ::= func Id '(' <parameters> ')' ':' '{' <stmt_list> '}'
        RULE_PARAMETERS                                                                          = 59, // <parameters> ::= <param>
        RULE_PARAMETERS_COMMA                                                                    = 60, // <parameters> ::= <param> ',' <parameters>
        RULE_PARAM_ID                                                                            = 61, // <param> ::= Id
        RULE_PARAM                                                                               = 62, // <param> ::= <assign>
        RULE_RETURN_STMT_RETURN                                                                  = 63, // <return_stmt> ::= return <expres>
        RULE_CALL_FUN_ID_DOT_LPAREN_RPAREN                                                       = 64, // <call_fun> ::= Id '.' '(' <arguments> ')'
        RULE_ARGUMENTS                                                                           = 65, // <arguments> ::= <expres>
        RULE_ARGUMENTS_COMMA                                                                     = 66, // <arguments> ::= <expres> ',' <arguments>
        RULE_DICTIONARY_ID_EQ_LBRACE_RBRACE                                                      = 67, // <dictionary> ::= Id '=' '{' <keys_values> '}'
        RULE_KEYS_VALUES                                                                         = 68, // <keys_values> ::= <key_value>
        RULE_KEYS_VALUES_COMMA                                                                   = 69, // <keys_values> ::= <key_value> ',' <key_value>
        RULE_KEY_VALUE_COLON                                                                     = 70, // <key_value> ::= <key> ':' <value>
        RULE_KEY_ID                                                                              = 71, // <key> ::= Id
        RULE_VALUE                                                                               = 72, // <value> ::= <expres>
        RULE_LIST_ID_EQ_LBRACKET_RBRACKET                                                        = 73, // <list> ::= <data_type> Id '=' '[' <elements> ']'
        RULE_LIST_ID_EQ_LBRACKET_RBRACKET2                                                       = 74, // <list> ::= <data_type> Id '=' '[' ']'
        RULE_ELEMENTS                                                                            = 75, // <elements> ::= <element>
        RULE_ELEMENTS_COMMA                                                                      = 76, // <elements> ::= <element> ',' <elements>
        RULE_ELEMENT                                                                             = 77, // <element> ::= <expres>
        RULE_PRINT_WRITE_LPAREN_RPAREN                                                           = 78, // <print> ::= write '(' <print_arguments> ')'
        RULE_PRINT_ARGUMENTS                                                                     = 79, // <print_arguments> ::= <expres>
        RULE_PRINT_ARGUMENTS_COMMA                                                               = 80, // <print_arguments> ::= <expres> ',' <print_arguments>
        RULE_TRY_CATCH_TRY_COLON_LBRACE_RBRACE_CATCH_COLON_LBRACE_RBRACE                         = 81, // <try_catch> ::= try ':' '{' <stmt_list> '}' catch ':' '{' <stmt_list> '}'
        RULE_TRY_CATCH_TRY_COLON_LBRACE_RBRACE_CATCH_COLON_LBRACE_RBRACE_END_COLON_LBRACE_RBRACE = 82, // <try_catch> ::= try ':' '{' <stmt_list> '}' catch ':' '{' <stmt_list> '}' end ':' '{' <stmt_list> '}'
        RULE_CLASS_CLASS_ID_COLON_LBRACE_RBRACE                                                  = 83, // <class> ::= class Id ':' '{' <class_body> '}'
        RULE_CLASS_CLASS_ID_LPAREN_RPAREN_COLON_LBRACE_RBRACE                                    = 84, // <class> ::= class Id '(' <Inheritance> ')' ':' '{' <class_body> '}'
        RULE_INHERITANCE_INHERITS_ID                                                             = 85, // <Inheritance> ::= inherits Id
        RULE_CLASS_BODY                                                                          = 86, // <class_body> ::= <class_members>
        RULE_CLASS_MEMBERS                                                                       = 87, // <class_members> ::= <class_member>
        RULE_CLASS_MEMBERS2                                                                      = 88, // <class_members> ::= <class_member> <class_members>
        RULE_CLASS_MEMBER                                                                        = 89, // <class_member> ::= <assign>
        RULE_CLASS_MEMBER2                                                                       = 90, // <class_member> ::= <function>
        RULE_CLASS_OBJECT_ID_EQ_ID_LPAREN_RPAREN                                                 = 91, // <class_object> ::= Id '=' Id '(' <arguments> ')'
        RULE_ACCESS_CLASSFUNCTION_ID_DOT_ID_LPAREN_RPAREN                                        = 92  // <access_classFunction> ::= Id '.' Id '(' <arguments> ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;
        public MyParser(string filename, ListBox lst , ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            this.lst = lst;
            this.ls = ls;

        }



        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;
            
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);

            parser.OnTokenRead += new LALRParser.TokenReadHandler(Parser_OnTokenRead);

        }

        private void Parser_OnTokenRead(LALRParser parser, TokenReadEventArgs args)
        {

            string info = args.Token.Text + "\t \t" + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);

        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSTIMES :
                //'+*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCH :
                //catch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COM :
                //com
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INHERITS :
                //inherits
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //to
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WRITE :
                //write
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESS_CLASSFUNCTION :
                //<access_classFunction>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALL_FUN :
                //<call_fun>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS2 :
                //<class>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_BODY :
                //<class_body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_MEMBER :
                //<class_member>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_MEMBERS :
                //<class_members>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_OBJECT :
                //<class_object>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT_STMT :
                //<comment_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA_TYPE :
                //<data_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DICTIONARY :
                //<dictionary>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE :
                //<do_while>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELEMENT :
                //<element>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELEMENTS :
                //<elements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRES :
                //<expres>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //<function>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GO :
                //<Go>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INHERITANCE :
                //<Inheritance>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEY :
                //<key>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEY_VALUE :
                //<key_value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEYS_VALUES :
                //<keys_values>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LIST :
                //<list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //<param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //<print>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_ARGUMENTS :
                //<print_arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_STMT :
                //<return_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRY_CATCH :
                //<try_catch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_GO :
                //<Go> ::= <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <statement> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<statement> ::= <while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<statement> ::= <do_while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<statement> ::= <function>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<statement> ::= <return_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT8 :
                //<statement> ::= <comment_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT9 :
                //<statement> ::= <call_fun>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT10 :
                //<statement> ::= <dictionary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT11 :
                //<statement> ::= <list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT12 :
                //<statement> ::= <try_catch>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT13 :
                //<statement> ::= <class>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT14 :
                //<statement> ::= <class_object>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT15 :
                //<statement> ::= <access_classFunction>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT16 :
                //<statement> ::= <print>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMENT_STMT_COM :
                //<comment_stmt> ::= com
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_ID_EQ :
                //<assign> ::= <data_type> Id '=' <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_INT :
                //<data_type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_FLOAT :
                //<data_type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_STRING :
                //<data_type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRES_PLUS :
                //<expres> ::= <term> '+' <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRES_MINUS :
                //<expres> ::= <term> '-' <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRES :
                //<expres> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <factor> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <factor> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <factor> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_ID :
                //<factor> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_CARET :
                //<factor> ::= <digit> '^' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<factor> ::= '(' <expres> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_TO_COMMA_RPAREN_COLON_LBRACE_RBRACE :
                //<for_stmt> ::= for '(' <assign> to <assign> ',' <step> ')' ':' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS_ID :
                //<step> ::= '--' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_MINUSMINUS :
                //<step> ::= Id '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS_ID :
                //<step> ::= '++' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_PLUSPLUS :
                //<step> ::= Id '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_EQ_ID_PLUS :
                //<step> ::= Id '=' Id '+' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_EQ_ID_MINUS :
                //<step> ::= Id '=' Id '-' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_PLUSEQ :
                //<step> ::= Id '+=' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_MINUSEQ :
                //<step> ::= Id '-=' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_EQ_ID_PLUSTIMES :
                //<step> ::= Id '=' Id '+*' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_EQ_ID_DIV :
                //<step> ::= Id '=' Id '/' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_TIMESEQ :
                //<step> ::= Id '*=' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_DIVEQ :
                //<step> ::= Id '/=' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_LBRACE_RBRACE :
                //<if_stmt> ::= if '(' <cond> ')' ':' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<if_stmt> ::= if '(' <cond> ')' ':' '{' <stmt_list> '}' else '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expres> <op> <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_COLON_LBRACE_RBRACE :
                //<while_stmt> ::= while '(' <cond> ')' ':' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN :
                //<do_while> ::= do '{' <stmt_list> '}' while '(' <cond> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_FUNC_ID_LPAREN_RPAREN_COLON_LBRACE_RBRACE :
                //<function> ::= func Id '(' <parameters> ')' ':' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS :
                //<parameters> ::= <param>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_COMMA :
                //<parameters> ::= <param> ',' <parameters>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM_ID :
                //<param> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM :
                //<param> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_STMT_RETURN :
                //<return_stmt> ::= return <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALL_FUN_ID_DOT_LPAREN_RPAREN :
                //<call_fun> ::= Id '.' '(' <arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS :
                //<arguments> ::= <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_COMMA :
                //<arguments> ::= <expres> ',' <arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DICTIONARY_ID_EQ_LBRACE_RBRACE :
                //<dictionary> ::= Id '=' '{' <keys_values> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYS_VALUES :
                //<keys_values> ::= <key_value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYS_VALUES_COMMA :
                //<keys_values> ::= <key_value> ',' <key_value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEY_VALUE_COLON :
                //<key_value> ::= <key> ':' <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEY_ID :
                //<key> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<value> ::= <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LIST_ID_EQ_LBRACKET_RBRACKET :
                //<list> ::= <data_type> Id '=' '[' <elements> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LIST_ID_EQ_LBRACKET_RBRACKET2 :
                //<list> ::= <data_type> Id '=' '[' ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTS :
                //<elements> ::= <element>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTS_COMMA :
                //<elements> ::= <element> ',' <elements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENT :
                //<element> ::= <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_WRITE_LPAREN_RPAREN :
                //<print> ::= write '(' <print_arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_ARGUMENTS :
                //<print_arguments> ::= <expres>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_ARGUMENTS_COMMA :
                //<print_arguments> ::= <expres> ',' <print_arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRY_CATCH_TRY_COLON_LBRACE_RBRACE_CATCH_COLON_LBRACE_RBRACE :
                //<try_catch> ::= try ':' '{' <stmt_list> '}' catch ':' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRY_CATCH_TRY_COLON_LBRACE_RBRACE_CATCH_COLON_LBRACE_RBRACE_END_COLON_LBRACE_RBRACE :
                //<try_catch> ::= try ':' '{' <stmt_list> '}' catch ':' '{' <stmt_list> '}' end ':' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_CLASS_ID_COLON_LBRACE_RBRACE :
                //<class> ::= class Id ':' '{' <class_body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_CLASS_ID_LPAREN_RPAREN_COLON_LBRACE_RBRACE :
                //<class> ::= class Id '(' <Inheritance> ')' ':' '{' <class_body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INHERITANCE_INHERITS_ID :
                //<Inheritance> ::= inherits Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_BODY :
                //<class_body> ::= <class_members>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_MEMBERS :
                //<class_members> ::= <class_member>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_MEMBERS2 :
                //<class_members> ::= <class_member> <class_members>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_MEMBER :
                //<class_member> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_MEMBER2 :
                //<class_member> ::= <function>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_OBJECT_ID_EQ_ID_LPAREN_RPAREN :
                //<class_object> ::= Id '=' Id '(' <arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESS_CLASSFUNCTION_ID_DOT_ID_LPAREN_RPAREN :
                //<access_classFunction> ::= Id '.' Id '(' <arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "\n - Error in line " + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "\n - Expected Tokens : " + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
        }

 

    }
}
