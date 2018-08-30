var app = angular.module("myApp", []);

app.value('shared', {});

app.service('userid', [function() {
  var id=1;
  return {
    setId : function(obj) {
      id = obj;
    },
    getId : function() {
      return id;
    }
  };
}]);

app.service('topicid', [function() {
  var id=1;
  return {
    setId : function(obj) {
      id = obj;
    },
    getId : function() {
      return id;
    }
  };
}]);

app.service('postid', [function() {
  var id=1;
  return {
    setId : function(obj) {
      id = obj;
    },
    getId : function() {
      return id;
    }
  };
}]);

app.controller("LoginController", ['$scope', '$http', 'userid', '$window', function($scope, $http, userid, $window) {
  $scope.loginnow = function() {
    alert("working");
    $http({
      url: "http://localhost:56967/api/users/",
      method: 'POST',
      contentType: 'application/json; charset=utf-8',
      data: {
        email: $scope.email,
        password: $scope.password
      }
    }).then(function(response) { // this is the success
      if (response.data.password == $scope.password) {
        userid.setId(response.data.userId);
        $window.open('bloghome.html', '_self');
      } else {
        alert("invalid username or password");
      }
    }, function(error) { // this is the error
      alert("Invalid Username or password");
    });
  };
}]);

app.controller("BlogHomeController", ['$scope', '$http', 'postid', '$window', 'userid', function( $scope, $http, postid, $window, userid) {
  $http.get("http://localhost:56967/api/posts/").then(function(response) {
    $scope.posts = response.data;
  });
  $scope.showpost = function(index) {
    postid.setId($scope.posts[index].postId);
    $window.open('blogpost.html', '_self');
  };
}]);

app.controller("TopicController", ['$scope', '$http', function($scope, $http) {
  $http.get("http://localhost:56967/api/topics/").then(function(response) {
    $scope.topics = response.data;
  });
}]);

app.controller("UserController", ['$scope', '$http', 'userid', function($scope, $http, userid) {
  var url = "http://localhost:56967/api/users/" + userid.getId().toString();
  //console.log(sessionService.getuserId);

  $scope.editdetails = function() {
    $http({
      url: url,
      method: 'PUT',
      contentType: 'application/json; charset=utf-8',
      data: {
        name: $scope.username,
        email: $scope.useremail,
        password: $scope.userpass
      }
    }).then(function(response) { // this is the success
      alert("Updated Successfully");
    });
  }
  $http.get(url).then(function(response) {
    $scope.userdetail = response.data;
    $scope.username = $scope.userdetail.name;
    $scope.useremail = $scope.userdetail.email;
    $scope.userpass = $scope.userdetail.password;
  });
}]);

app.controller("PostController", ['$scope', '$http', 'userid', 'postid', function($scope, $http, userid, postid) {
  $http.get("http://localhost:56967/api/topics/").then(function(response) {
    $scope.topics = response.data;
  });
  $scope.submitpost = function() {
    var postTitle = $scope.topictitle.toString();
    var postDetail = $scope.topicdetail.toString();
    var url = "http://localhost:56967/api/users/" + userid.getId().toString();
    $http({
      url: "http://localhost:56967/api/posts/",
      method: 'POST',
      contentType: 'application/json; charset=utf-8',
      data: {
        "title": postTitle,
        "postDetail": postDetail,
        "userId": userid.getId(),
        "topicId": $scope.topic.id
      }
    }).then(function(response) { // this is the success
      alert("Posted Successfully");
    }, function(error) { // this is the error
      alert("Error");
    });
  };
}]);


app.controller("SignUpController", ["$scope", "$http", "$window", function($scope, $http, $window) {
  $scope.submitdata = function() {
    $http({
      url: "http://localhost:56967/api/users/1",
      method: 'POST',
      contentType: 'application/json; charset=utf-8',
      data: {
        name: $scope.name,
        email: $scope.email,
        password: $scope.password
      }
    }).then(function(response) { // this is the success
      if (response == 403) {
        alert("Email already exists");
      } else {
        alert("Account created. Login now.")
        $window.open('bloglogin.html', '_self');
      }
    }, function(error) { // this is the error
      alert("Unknown Error, try later");
    });
  };
}]);

app.controller("BlogShowController", ['$scope', '$http', 'postid', 'userid', function($scope, $http, postid, userid) {

  $scope.submitcomment = function() {
    $http({
      url: "http://localhost:56967/api/comments",
      method: 'POST',
      contentType: 'application/json; charset=utf-8',
      data: {
        userId: userid.getId(),
        postId: postid.getId(),
        commentDetail: $scope.comment
      }
    }).then(function(response) { // this is the success
      alert("Successfully commented");
      var url = "http://localhost:56967/api/posts/" + postid.getId().toString() + "/comments";
      $http.get(url).then(function(response) {
        $scope.comments = response.data;
      });
    }, function(error) { // this is the error
      alert("Unknown Error, try later");
    });
  };

  var url = "http://localhost:56967/api/posts/" + postid.getId().toString();
  $http.get(url).then(function(response) {
    $scope.post = response.data;
  });
  var url = "http://localhost:56967/api/posts/" + postid.getId().toString() + "/comments";
  $http.get(url).then(function(response) {
    $scope.comments = response.data;
  });
  $http.get("http://localhost:56967/api/topics/").then(function(response) {
    $scope.topics = response.data;
  });
}]);
