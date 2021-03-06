// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "SqlParser.fsp"

open FsLexTest.Sql

# 10 "SqlParser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | ASC
  | DESC
  | SELECT
  | FROM
  | WHERE
  | ORDER
  | BY
  | JOIN
  | INNER
  | LEFT
  | RIGHT
  | ON
  | EQ
  | LT
  | LE
  | GT
  | GE
  | COMMA
  | AND
  | OR
  | FLOAT of (float)
  | INT of (int)
  | ID of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_ASC
    | TOKEN_DESC
    | TOKEN_SELECT
    | TOKEN_FROM
    | TOKEN_WHERE
    | TOKEN_ORDER
    | TOKEN_BY
    | TOKEN_JOIN
    | TOKEN_INNER
    | TOKEN_LEFT
    | TOKEN_RIGHT
    | TOKEN_ON
    | TOKEN_EQ
    | TOKEN_LT
    | TOKEN_LE
    | TOKEN_GT
    | TOKEN_GE
    | TOKEN_COMMA
    | TOKEN_AND
    | TOKEN_OR
    | TOKEN_FLOAT
    | TOKEN_INT
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | ASC  -> 1 
  | DESC  -> 2 
  | SELECT  -> 3 
  | FROM  -> 4 
  | WHERE  -> 5 
  | ORDER  -> 6 
  | BY  -> 7 
  | JOIN  -> 8 
  | INNER  -> 9 
  | LEFT  -> 10 
  | RIGHT  -> 11 
  | ON  -> 12 
  | EQ  -> 13 
  | LT  -> 14 
  | LE  -> 15 
  | GT  -> 16 
  | GE  -> 17 
  | COMMA  -> 18 
  | AND  -> 19 
  | OR  -> 20 
  | FLOAT _ -> 21 
  | INT _ -> 22 
  | ID _ -> 23 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_ASC 
  | 2 -> TOKEN_DESC 
  | 3 -> TOKEN_SELECT 
  | 4 -> TOKEN_FROM 
  | 5 -> TOKEN_WHERE 
  | 6 -> TOKEN_ORDER 
  | 7 -> TOKEN_BY 
  | 8 -> TOKEN_JOIN 
  | 9 -> TOKEN_INNER 
  | 10 -> TOKEN_LEFT 
  | 11 -> TOKEN_RIGHT 
  | 12 -> TOKEN_ON 
  | 13 -> TOKEN_EQ 
  | 14 -> TOKEN_LT 
  | 15 -> TOKEN_LE 
  | 16 -> TOKEN_GT 
  | 17 -> TOKEN_GE 
  | 18 -> TOKEN_COMMA 
  | 19 -> TOKEN_AND 
  | 20 -> TOKEN_OR 
  | 21 -> TOKEN_FLOAT 
  | 22 -> TOKEN_INT 
  | 23 -> TOKEN_ID 
  | 26 -> TOKEN_end_of_input
  | 24 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 26 
let _fsyacc_tagOfErrorTerminal = 24

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | ASC  -> "ASC" 
  | DESC  -> "DESC" 
  | SELECT  -> "SELECT" 
  | FROM  -> "FROM" 
  | WHERE  -> "WHERE" 
  | ORDER  -> "ORDER" 
  | BY  -> "BY" 
  | JOIN  -> "JOIN" 
  | INNER  -> "INNER" 
  | LEFT  -> "LEFT" 
  | RIGHT  -> "RIGHT" 
  | ON  -> "ON" 
  | EQ  -> "EQ" 
  | LT  -> "LT" 
  | LE  -> "LE" 
  | GT  -> "GT" 
  | GE  -> "GE" 
  | COMMA  -> "COMMA" 
  | AND  -> "AND" 
  | OR  -> "OR" 
  | FLOAT _ -> "FLOAT" 
  | INT _ -> "INT" 
  | ID _ -> "ID" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | ASC  -> (null : System.Object) 
  | DESC  -> (null : System.Object) 
  | SELECT  -> (null : System.Object) 
  | FROM  -> (null : System.Object) 
  | WHERE  -> (null : System.Object) 
  | ORDER  -> (null : System.Object) 
  | BY  -> (null : System.Object) 
  | JOIN  -> (null : System.Object) 
  | INNER  -> (null : System.Object) 
  | LEFT  -> (null : System.Object) 
  | RIGHT  -> (null : System.Object) 
  | ON  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | FLOAT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; |]
let _fsyacc_action_rows = 2
let _fsyacc_actionTableElements = [|0us; 16385us; 0us; 49152us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 1us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 0us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; |]
let _fsyacc_reductions ()  =    [| 
# 205 "SqlParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 214 "SqlParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 24 "SqlParser.fsp"
                           "Nothing to see here"
                   )
# 24 "SqlParser.fsp"
                 : string));
|]
# 225 "SqlParser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 27;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : string =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
