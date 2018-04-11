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
        console.log("My Result:" + JSON.stringify(results));
        db.close();
        return results;
    });
}

// Insert Record
var insertDocuments = function (userid, data, callback) {
    return ExecuteFunctions(function (db) {
        data.UserID = userid;
        const results = db.collection('tasks')
            .insert(data);
        return results;
    })
        //.then(docs => callback(null, docs))
        //.catch(err => callback(err));
}

// Edit by ID
var EditDocuments = function (id, data, callback) {
    return ExecuteFunctions(function (db) {
        delete data._id;
        console.log("id:" + id);
        console.log("Data:" + JSON.stringify(data));
        const results = db.collection('tasks')
            .update({ "_id": ObjectId(id) }, data);
        return results;
    })
        //.then(docs => callback(null, docs))
        //.catch(err => callback(err));
}

// Delete by ID
var DeleteOneByID = function (userid, id, callback) {
    return ExecuteFunctions(function (db) {
        const results = db.collection('tasks')
            .deleteOne({ "_id": ObjectId(id), 'UserID': userid });
        return results;
    })
        //.then(docs => callback(null, docs))
        //.catch(err => callback(err));
}

// Query Collection
var findDocument = function (userid, name, callback) {
    return ExecuteFunctions(function (db) {
        const collection = db.collection('tasks').find({ 'UserID': userid });
        var criteria = ".*" + name + ".*";
        const docs = collection.findOne({ detail: { $regex: criteria } });
        return docs;
    })
        //.then(docs => callback(null, docs))
        //.catch(err => callback(err));
}

// Note: Removed callback due to warning: "UnhandledPromiseRejectionWarning: Unhandled promise rejection (rejection id: 1): TypeError: callback is not a function"
var findAllDocuments = function (userid, callback) {
    return ExecuteFunctions(function (db) {
        const collection = db.collection('tasks');
        const docs = collection.find({ 'UserID': userid }).toArray();
        return docs;
    })
        //.then(docs => callback(null, docs))
        //.catch(err => callback(err));
}

module.exports.mongoDB = {
    insertDocuments,
    EditDocuments,
    findDocument,
    DeleteOneByID,
    findAllDocuments
};
