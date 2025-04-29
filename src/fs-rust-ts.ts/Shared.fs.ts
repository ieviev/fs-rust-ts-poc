import { Record } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/Types.js";
import { IEquatable, IMap } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/Util.js";
import { int32 } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/Int32.js";
import { record_type, class_type, int32_type, string_type, TypeInfo } from "./fable_modules/fable-library-ts.5.0.0-alpha.12/Reflection.js";

export class HashMapAsAService extends Record implements IEquatable<HashMapAsAService> {
    readonly dictionary: IMap<string, int32>;
    constructor(dictionary: IMap<string, int32>) {
        super();
        this.dictionary = dictionary;
    }
}

export function HashMapAsAService_$reflection(): TypeInfo {
    return record_type("Shared.HashMapAsAService", [], HashMapAsAService, () => [["dictionary", class_type("System.Collections.Generic.Dictionary`2", [string_type, int32_type])]]);
}

