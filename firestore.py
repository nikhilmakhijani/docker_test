
from google.cloud import firestore

# Get the source and destination Firestore databases
src_db = firestore.Client(project='')
dest_db = firestore.Client(project='')


for collection in ["", ""]:
    # Get the source collection
    src_col = src_db.collection(collection)
    # Create a batch to write documents to the destination collection
    batch = dest_db.batch()

# Iterate through all documents in the source collection
    for doc in src_col.stream():
    # Get the document data
        data = doc.to_dict()
    # Add the document to the batch with the same name
        batch.set(dest_db.collection(collection).document(doc.id), data)
    # Commit the batch to write the documents to the destination collection
        batch.commit()
