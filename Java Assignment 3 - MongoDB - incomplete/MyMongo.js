var mongoDB = require('mongodb');
var MongoClient = mongoDB.MongoClient
var ObjectId = mongoDB.ObjectID;
var co = require('co');

// Connection URL
var url = 'mongodb://localhost/tasksDB';

var ExecuteFunctions = function (func) {
    return co(function* () {
        var db = yield MongoClient.connect(url);
        const results = yield func(db);
        console.log(results)
        db.close();
        return results;
    });
}

// Insert Record
var insertDocuments = function (data, callback) {
    return ExecuteFunctions(function (db) {
        const results = db.collection('tasks')
            .insert(data);
        return results;
    });
}
// Edit by ID
var EditDocuments = function (id, data, callback) {
    return ExecuteFunctions(function (db) {
        delete data._id;
        const results = db.collection('tasks')
            .update({ "_id": ObjectId(id) }, data);
        return results;
    });
}
// Delete by ID
var DeleteOneByID = function (id, callback) {
    return ExecuteFunctions(function (db) {
        const results = db.collection('tasks')
            .deleteOne({ "_id": ObjectId(id) });
        return results;
    });
}

// Query Collection
var findDocument = function (name) {
    return ExecuteFunctions(function (db) {
        const collection = db.collection('tasks');
        var criteria = ".*" + name + ".*";
        const docs = collection.findOne({ detail: { $regex: criteria } });
        return docs;
    });
}

var findAllDocuments = function (callback) {
    return ExecuteFunctions(function (db) {
        const collection = db.collection('tasks');
        const docs = collection.find().toArray();
        return docs;
    })
        .then(docs => callback(null, docs))
        .catch(err => callback(err));
}

// Create Index
var indexCollection = function () {
    return ExecuteFunctions(function (db) {
        const results = db.collection('tasks').createIndex(
            { "name": 1 },
            null
        );
        return results;
    });
};

// Perform Aggregation
var aggregateDocuments = function (callback) {
    return ExecuteFunctions(function (db) {
        const results = db.collection('restaurants')
            .aggregate(
                [{ '$match': { "categories": "Bakery" } },
                { '$group': { '_id': "$stars", 'count': { '$sum': 1 } } }])
            .toArray();
        return results;
    });
}

module.exports.mongoDB = {
    insertDocuments,
    EditDocuments,
    findDocument,
    DeleteOneByID,
    findAllDocuments
};