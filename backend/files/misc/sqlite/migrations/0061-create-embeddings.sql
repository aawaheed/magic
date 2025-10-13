
/*
 * Dropping old virtual VSS table(s).
 */
alter table ml_training_snippets add column embeddings blob;
