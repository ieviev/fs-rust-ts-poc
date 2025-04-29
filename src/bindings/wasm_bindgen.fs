module bindings.wasm_bindgen

open fsil_rust
open Fable.Core

#if FABLE_COMPILER_JAVASCRIPT
type JsValue<'input> = 'input
#else
[<Erase; Emit("wasm_bindgen::JsValue")>]
type JsValue<'input> =
    abstract as_f64: unit -> Option<float>
#endif


[<Erase>]
module JsValue =
    [<Emit("wasm_bindgen::JsValue::NULL")>]
    let NULL: JsValue<string> = nativeOnly

    [<Emit("wasm_bindgen::JsValue::from_f64($0)")>]
    let inline from_f64(_: float) : JsValue<float> = nativeOnly

    [<Emit("wasm_bindgen::JsValue::from_str($0)")>]
    let inline from_str(_: str) : JsValue<string> = nativeOnly


#if FABLE_COMPILER_JAVASCRIPT || FABLE_COMPILER_TYPESCRIPT
type JSFunction1<'input, 'output> = 'input -> 'output
#else
[<Erase; Emit("&js_sys::Function")>]
type JSFunction1<'input, 'output> =
    abstract call1: Ref<JsValue<string>> * Ref<JsValue<'input>> -> Result<JsValue<'output>, JsValue<obj>>
    abstract call0: Ref<JsValue<string>> -> Result<JsValue<'output>, JsValue<string>>
#endif

