# INFO; Transform files using the Hyperlambda Generator

Magic has good support for transforming CSV files, XML files, YAML files, JSON files, etc, back and forth. Magic has very good support for parsing text through the Hyperlambda Generator. You can even query it for its capabilities with prompts as follows;

* "Return all slots in the 'data.' namespace"
* "Return all slots in the 'strings.' namespace"

In addition you can use prompts such as for instance

```plaintext
Load '/etc/customers.json', transform it to lambda, and return all rows having a 'status' value of 'xyz'"
```

You can do the same for YAML files, Hyperlambda files, and CSV files. Allowing you to use files like these almost like a 'database'. Below is another example.

```plaintext
Load '/etc/customers.json', transform it to YAML, and save it as '/etc/backup/foo.yaml'"
```
