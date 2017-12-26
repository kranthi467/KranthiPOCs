var MongoClient = require('mongodb').MongoClient
  , co = require('co')
  , assert = require('assert');

var ObjectId = require('mongodb').ObjectID;

var data = { "name": "Sun Bakery Trattoria", "stars": 4, "categories": ["Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"] };

// 1. Connect to MongoDB instance running on localhost

// Connection URL
var url = 'mongodb://localhost/test';

co(function* () {
  const db = yield MongoClient.connect(url);
  console.log("Connected successfully to server");

  //yield insertDocuments(db,data, null);
  //yield findDocuments(db, null);
  //yield indexCollection(db, null);
  // yield aggregateDocuments(db, null);
  //yield DeleteOneByID(db, null);

  //yield findAllDocuments(db, null);

  var results = yield db.collection('tasks')
    .insert(data);
  console.log(results)
  db.close();
}).catch(err => console.log(err));

// 2. Insert
var insertDocuments = function (db, data, callback) {
  return co(function* () {
    const results = yield db.collection('tasks')
      .insert(data);
    console.log(results)
    return results;
  });
}
// Edit by ID
var EditDocuments = function (db, callback) {
  return co(function* () {
    const results = yield db.collection('tasks')
      .update({ "_id": ObjectId("59d63fccdf72f22f1c8935e3") }, { "name": "Sun Bakery Trattoria" });
    console.log(results)
    return results;
  });
}
//delete by ID
var DeleteOneByID = function (db, callback) {
  return co(function* () {
    const results = yield db.collection('tasks')
      .deleteOne({ "_id": ObjectId("59d63fccdf72f22f1c8935e9") });
    console.log(results)
    return results;
  });
}

// 3. Query Collection
var findDocuments = function (db) {
  return co(function* () {
    // Get the documents collection
    const collection = db.collection('tasks');
    const docs = yield collection.find({ "_id": ObjectId("59d63fccdf72f22f1c8935e3") }).toArray();
    console.log("Found the following records");
    console.log(docs)
    return docs;
  });
}


var findAllDocuments = function (db) {
  return co(function* () {
    // Get the documents collection
    const collection = db.collection('tasks');
    const docs = yield collection.find({}).toArray();
    console.log("Found the following records");
    console.log(docs)
    return docs;
  });
}

// 4. Create Index
var indexCollection = function (db) {
  return co(function* () {
    const results = yield db.collection('restaurants').createIndex(
      { "name": 1 },
      null
    );

    console.log(results);
    return results;
  });
};

// 5. Perform Aggregation

var aggregateDocuments = function (db, callback) {
  return co(function* () {
    const results = yield db.collection('restaurants')
      .aggregate(
      [{ '$match': { "categories": "Bakery" } },
      { '$group': { '_id': "$stars", 'count': { '$sum': 1 } } }])
      .toArray();

    console.log(results)
    return results;
  });
}