#![allow(unused, dead_code, non_snake_case, non_upper_case_globals,)]
mod module_90cf8630 {
    pub mod Rust {
        use super::*;
        use wasm_bindgen::prelude::*;
        use crate::Shared::HashMapAsAService;
        use std::collections::HashMap;
        #[wasm_bindgen]
        pub fn log_something_with_callback(input: String,
                                           callback: &js_sys::Function) {
            callback.call1(&wasm_bindgen::JsValue::NULL,
                           &wasm_bindgen::JsValue::from_str(input.as_str()));
            {
                let response =
                    callback.call1(&wasm_bindgen::JsValue::NULL,
                                   &wasm_bindgen::JsValue::from_str("\"Hello from rust!\"".to_string().as_str()));
                ()
            }
        }
        #[wasm_bindgen]
        pub fn get_item(item: String, arg1: *mut HashMapAsAService)
         -> Option<i32> {
            let compiler: &mut HashMapAsAService =
                unsafe{arg1.as_mut().unwrap()};
            let mapvalue: &i32 = &((compiler).dictionary)[&item];
            Some(*mapvalue)
        }
        #[wasm_bindgen]
        pub fn num_of_items(arg1_1: *mut HashMapAsAService) -> i32 {
            let compiler_1: &mut HashMapAsAService =
                unsafe{arg1_1.as_mut().unwrap()};
            let map: &mut HashMap<String, i32> = &mut (compiler_1).dictionary;
            map.len() as i32
        }
        #[wasm_bindgen]
        pub fn add_item(item_1: String, value: i32, p: *mut HashMapAsAService)
         -> String {
            let compiler_2: &mut HashMapAsAService =
                unsafe{p.as_mut().unwrap()};
            (compiler_2).dictionary.insert(item_1, value);
            {
                let response_1: String =
                    "added item successfully!".to_string();
                response_1
            }
        }
        #[wasm_bindgen]
        pub fn alloc_compiler() -> *mut HashMapAsAService {
            let comp: HashMapAsAService =
                HashMapAsAService{dictionary: HashMap::<String, i32>::new(),};
            let mutptr: *mut HashMapAsAService =
                Box::into_raw(Box::new(comp));
            mutptr
        }
        #[wasm_bindgen]
        pub fn free_compiler(compiler_3: *mut HashMapAsAService) {
            unsafe {drop(Box::from_raw(compiler_3))};
        }
    }
}
pub use module_90cf8630::*;
#[path = "../../fsil/src/fsil.rust/fsil_rust.fs.rs"]
mod module_6e27547d;
pub use module_6e27547d::*;
#[path = "../../fsil/src/fsil/fsil.fs.rs"]
mod module_2d25e3ec;
pub use module_2d25e3ec::*;
#[path = "./Shared.fs.rs"]
mod module_e675f4f9;
pub use module_e675f4f9::*;
#[path = "./wasm_bindgen.fs.rs"]
mod module_cbc488aa;
pub use module_cbc488aa::*;
