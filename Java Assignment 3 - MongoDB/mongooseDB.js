var mongoose = require('mongoose');

// Connection URL
var url = 'mongodb://localhost/tasksDB';
mongoose.connect(url);

var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

// User schema
var UserSchema = new Schema({
    username: { 'type': String, 'unique': true, 'required': true, index: true, minlength:6 },
    email: { 'type': String, 'unique': true, 'required': true, minlength:6  },
    password: { 'type': String, 'required': true, minlength:6  }
});

var userModel = mongoose.model('users', UserSchema);

module.exports.Users = userModel;


// var user = {
//     username: "Kranthi3",
//     email: "Kranthi3@ggktech.com",
//     password: "Kranthi"
// };

// userModel.create(user)
//     .then(results => console.log(results))
//     .catch(err => console.log(err));

// var findUser = function (data) {
//     return new Promise(function (resolve, reject) {
//         var query = userModel.findOne({ 'username': data });
//         query.exec(function (err, user) {
//             if (err) reject(err);
//             resolve(user);
//         });
//     });
// }
// findUser("Kranthi21").then(results => console.log(results))
// .catch(err => console.log(err));;
// userModel.findById("5a8a74517ec28c4788c014b4")
//     .then(result => {
//         result.email = "kkr1@kr.com";
//         result.save(function (err, user) {
//             console.log(user);
//         });
//     })
//     .catch(err => console.log(err));