pub mod Shared {
    use super::*;
    use std::collections::HashMap;
    #[derive(Clone, Debug,)]
    pub struct HashMapAsAService {
        pub dictionary: HashMap<String, i32>,
    }
}
