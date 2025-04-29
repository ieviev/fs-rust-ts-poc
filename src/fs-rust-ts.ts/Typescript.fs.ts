import * as rust_library from "rust_library";
import { concat, interpolate, toConsole } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/String.js";
import { int32 } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/Int32.js";
import { some, Option } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/Option.js";

export const p_compiler: any = rust_library.alloc_compiler();

export const response1: string = rust_library.add_item("hello", 123, p_compiler);

toConsole(interpolate("%A%P()", [response1]));

export const response2: string = rust_library.add_item("world", 456, p_compiler);

toConsole(interpolate("%A%P()", [response2]));

export const num_of_items: int32 = rust_library.num_of_items(p_compiler);

toConsole(interpolate("%A%P()", [`num of items: ${num_of_items}`]));

export const item1: Option<int32> = rust_library.get_item("hello", p_compiler);

toConsole(interpolate("%A%P()", [`value1: ${item1}`]));

export const item2: Option<int32> = rust_library.get_item("world", p_compiler);

toConsole(interpolate("%A%P()", [`value2: ${item2}`]));

rust_library.log_something_with_callback("string from js", (callbackstr: string): int32 => {
    console.log(some(concat("logging ", ...callbackstr)));
    return 1234;
});

rust_library.free_compiler(p_compiler);

