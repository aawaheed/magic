
/*
 * Dropping old virtual VSS table(s).
 */
select * from vector_quantize_cleanup('ml_training_snippets', 'embeddings');