//{
//  "exclude": [
//    "**/bin",
//    "**/bower_components",
//    "**/jspm_packages",
//    "**/node_modules",
//    "**/obj",
//    "**/platforms"
//  ]
//}

var angApp = angular.module("angApp", []);

(function (app) {
    "use strict";
    app.controller("customerOrderBlock", function () {
        var vm = this;

        //var modal = $('#fileUploadModal');

        vm.fileUpload = function () { 
            $("#fileUploadModal").modal('show');                      
           
        };

        vm.fileClose = function () {           
            $('#fileUploadModal').modal('hide');
        };
    });
})(angApp);

