
module Shared

open System.Collections.Generic
open Fable.Core
open fsil_rust
open bindings.wasm_bindgen

// think fable remoting but for wasm_bindgen
[<Struct>]
type HashMapAsAService = { dictionary: Dictionary<string, int> }


[<Erase>]
type WasmApi =
    abstract member alloc_compiler: unit -> MutPtr<HashMapAsAService>
    abstract member free_compiler: MutPtr<HashMapAsAService> -> unit

    abstract member log_something_with_callback:
        input: string -> logfn: JSFunction1<string, int> -> unit

    abstract member add_item:
        item: string -> value: int -> MutPtr<HashMapAsAService> -> string

    abstract member get_item: item: string -> MutPtr<HashMapAsAService> -> Option<int>
    abstract member num_of_items: MutPtr<HashMapAsAService> -> int
