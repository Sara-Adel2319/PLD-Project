
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

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
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_MINUSMINUS          =  4, // '--'
        SYMBOL_EXCLAM              =  5, // '!'
        SYMBOL_LPAREN              =  6, // '('
        SYMBOL_RPAREN              =  7, // ')'
        SYMBOL_TIMES               =  8, // '*'
        SYMBOL_DIV                 =  9, // '/'
        SYMBOL_COLONDO             = 10, // ':do'
        SYMBOL_LBRACE              = 11, // '{'
        SYMBOL_RBRACE              = 12, // '}'
        SYMBOL_PLUS                = 13, // '+'
        SYMBOL_PLUSPLUS            = 14, // '++'
        SYMBOL_LT                  = 15, // '<'
        SYMBOL_LTEQ                = 16, // '<='
        SYMBOL_LTGT                = 17, // '<>'
        SYMBOL_EQ                  = 18, // '='
        SYMBOL_EQEQ                = 19, // '=='
        SYMBOL_GT                  = 20, // '>'
        SYMBOL_GTEQ                = 21, // '>='
        SYMBOL_BREAK               = 22, // break
        SYMBOL_CASE                = 23, // case
        SYMBOL_DEFAULT             = 24, // default
        SYMBOL_DO                  = 25, // do
        SYMBOL_ELSE                = 26, // else
        SYMBOL_END                 = 27, // end
        SYMBOL_FOR                 = 28, // for
        SYMBOL_IDENTIFIER          = 29, // Identifier
        SYMBOL_IF                  = 30, // if
        SYMBOL_INTEGER             = 31, // Integer
        SYMBOL_START               = 32, // start
        SYMBOL_STRINGLITERAL       = 33, // StringLiteral
        SYMBOL_SWITCH              = 34, // switch
        SYMBOL_THEN                = 35, // then
        SYMBOL_WHILE               = 36, // while
        SYMBOL_ADDEXP              = 37, // <Add Exp>
        SYMBOL_CASELIST            = 38, // <CaseList>
        SYMBOL_DEFAULT2            = 39, // <Default>
        SYMBOL_DOWHILELOOP         = 40, // <DoWhileLoop>
        SYMBOL_EXPRESSION          = 41, // <Expression>
        SYMBOL_FORLOOP             = 42, // <ForLoop>
        SYMBOL_IFSTATEMENT         = 43, // <IfStatement>
        SYMBOL_INCDEC              = 44, // <IncDec>
        SYMBOL_INITIALIZATION      = 45, // <Initialization>
        SYMBOL_MULTEXP             = 46, // <Mult Exp>
        SYMBOL_NEGATEEXP           = 47, // <Negate Exp>
        SYMBOL_PROGRAM             = 48, // <Program>
        SYMBOL_STATEMENT           = 49, // <Statement>
        SYMBOL_STATEMENTLIST       = 50, // <StatementList>
        SYMBOL_SWITCHSTATEMENT     = 51, // <SwitchStatement>
        SYMBOL_VALUE               = 52, // <Value>
        SYMBOL_VARIABLEDECLARATION = 53, // <VariableDeclaration>
        SYMBOL_WHILELOOP           = 54  // <WhileLoop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                     =  0, // <Program> ::= start <StatementList> end
        RULE_STATEMENTLIST                                         =  1, // <StatementList> ::= 
        RULE_STATEMENTLIST_EXCLAM                                  =  2, // <StatementList> ::= <StatementList> <Statement> '!'
        RULE_STATEMENTLIST_EXCLAM2                                 =  3, // <StatementList> ::= <Statement> '!'
        RULE_STATEMENT                                             =  4, // <Statement> ::= <VariableDeclaration>
        RULE_STATEMENT2                                            =  5, // <Statement> ::= <IfStatement>
        RULE_STATEMENT3                                            =  6, // <Statement> ::= <SwitchStatement>
        RULE_STATEMENT4                                            =  7, // <Statement> ::= <ForLoop>
        RULE_STATEMENT5                                            =  8, // <Statement> ::= <WhileLoop>
        RULE_STATEMENT6                                            =  9, // <Statement> ::= <DoWhileLoop>
        RULE_VARIABLEDECLARATION_IDENTIFIER_EQ_EXCLAM              = 10, // <VariableDeclaration> ::= Identifier '=' <Expression> '!'
        RULE_IFSTATEMENT_IF_THEN                                   = 11, // <IfStatement> ::= if <Expression> then <StatementList>
        RULE_IFSTATEMENT_IF_THEN_ELSE                              = 12, // <IfStatement> ::= if <Expression> then <StatementList> else <StatementList>
        RULE_SWITCHSTATEMENT_SWITCH_LBRACE_RBRACE                  = 13, // <SwitchStatement> ::= switch <Expression> '{' <CaseList> <Default> '}'
        RULE_CASELIST                                              = 14, // <CaseList> ::= 
        RULE_CASELIST_CASE_COLONDO_BREAK_EXCLAM                    = 15, // <CaseList> ::= <CaseList> case <Expression> ':do' <StatementList> break '!'
        RULE_CASELIST_CASE_DO_BREAK_EXCLAM                         = 16, // <CaseList> ::= case <Expression> do <StatementList> break '!'
        RULE_DEFAULT_DEFAULT_DO_BREAK_EXCLAM                       = 17, // <Default> ::= default do <StatementList> break '!'
        RULE_FORLOOP_FOR_LPAREN_EXCLAM_EXCLAM_RPAREN_LBRACE_RBRACE = 18, // <ForLoop> ::= for '(' <Initialization> '!' <Expression> '!' <IncDec> ')' '{' <StatementList> '}'
        RULE_INITIALIZATION_IDENTIFIER_EQ                          = 19, // <Initialization> ::= Identifier '=' <Expression>
        RULE_INCDEC_IDENTIFIER_PLUSPLUS                            = 20, // <IncDec> ::= Identifier '++'
        RULE_INCDEC_IDENTIFIER_MINUSMINUS                          = 21, // <IncDec> ::= Identifier '--'
        RULE_WHILELOOP_WHILE_THEN                                  = 22, // <WhileLoop> ::= while <Expression> then <StatementList>
        RULE_DOWHILELOOP_DO_WHILE                                  = 23, // <DoWhileLoop> ::= do <StatementList> while <Expression>
        RULE_EXPRESSION_GT                                         = 24, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT                                         = 25, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ                                       = 26, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ                                       = 27, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQEQ                                       = 28, // <Expression> ::= <Expression> '==' <Add Exp>
        RULE_EXPRESSION_LTGT                                       = 29, // <Expression> ::= <Expression> '<>' <Add Exp>
        RULE_EXPRESSION                                            = 30, // <Expression> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                           = 31, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                          = 32, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                = 33, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                         = 34, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV                                           = 35, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP                                               = 36, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                                       = 37, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                                             = 38, // <Negate Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER                                      = 39, // <Value> ::= Identifier
        RULE_VALUE_INTEGER                                         = 40, // <Value> ::= Integer
        RULE_VALUE_STRINGLITERAL                                   = 41, // <Value> ::= StringLiteral
        RULE_VALUE_LPAREN_RPAREN                                   = 42  // <Value> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
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

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
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

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONDO :
                //':do'
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

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
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

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
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

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASELIST :
                //<CaseList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT2 :
                //<Default>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOWHILELOOP :
                //<DoWhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP :
                //<ForLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCDEC :
                //<IncDec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITIALIZATION :
                //<Initialization>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSTATEMENT :
                //<SwitchStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<VariableDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILELOOP :
                //<WhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<Program> ::= start <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST_EXCLAM :
                //<StatementList> ::= <StatementList> <Statement> '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST_EXCLAM2 :
                //<StatementList> ::= <Statement> '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <IfStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <SwitchStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <ForLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <WhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <DoWhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER_EQ_EXCLAM :
                //<VariableDeclaration> ::= Identifier '=' <Expression> '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_THEN :
                //<IfStatement> ::= if <Expression> then <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_THEN_ELSE :
                //<IfStatement> ::= if <Expression> then <StatementList> else <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTATEMENT_SWITCH_LBRACE_RBRACE :
                //<SwitchStatement> ::= switch <Expression> '{' <CaseList> <Default> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST :
                //<CaseList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLONDO_BREAK_EXCLAM :
                //<CaseList> ::= <CaseList> case <Expression> ':do' <StatementList> break '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_DO_BREAK_EXCLAM :
                //<CaseList> ::= case <Expression> do <StatementList> break '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULT_DEFAULT_DO_BREAK_EXCLAM :
                //<Default> ::= default do <StatementList> break '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORLOOP_FOR_LPAREN_EXCLAM_EXCLAM_RPAREN_LBRACE_RBRACE :
                //<ForLoop> ::= for '(' <Initialization> '!' <Expression> '!' <IncDec> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZATION_IDENTIFIER_EQ :
                //<Initialization> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_IDENTIFIER_PLUSPLUS :
                //<IncDec> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_IDENTIFIER_MINUSMINUS :
                //<IncDec> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_THEN :
                //<WhileLoop> ::= while <Expression> then <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILELOOP_DO_WHILE :
                //<DoWhileLoop> ::= do <StatementList> while <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTGT :
                //<Expression> ::= <Expression> '<>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
                //<Value> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
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
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
