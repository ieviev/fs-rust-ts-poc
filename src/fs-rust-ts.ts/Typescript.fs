open Fable.Core

[<Fable.Core.ImportAll("rust_library")>]
let api: Shared.WasmApi = nativeOnly

let p_compiler = api.alloc_compiler ()

let response1 = api.add_item "hello" 123 p_compiler
print response1
let response2 = api.add_item "world" 456 p_compiler
print response2

let num_of_items = api.num_of_items (p_compiler)
print $"num of items: {num_of_items}"

let item1 = api.get_item "hello" (p_compiler)
print $"value1: {item1}"

let item2 = api.get_item "world" (p_compiler)
print $"value2: {item2}"

let _ =
    api.log_something_with_callback "string from js" (fun callbackstr ->
        JS.console.log ($"logging {callbackstr}")
        1234)

api.free_compiler (p_compiler)
