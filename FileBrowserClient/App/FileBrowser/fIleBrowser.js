(function() {
    var app = angular.module('fileBrowserApp', []);

    app.controller('browserController', ['$scope', '$http', '$compile', function($scope, $http, $compile){
        this.path = '';
        this.folder  = '';
        this.upper = false;

        this.folderData = {};

        this.init = function(){
            getFolderData();
        };

        this.onFolderClick = function(folderName){
            $scope.browser.folder = folderName;
            $scope.browser.upper = false;
            getFolderData();
        };

        this.onDotsClick = function(){
            $scope.browser.folder = '';
            $scope.browser.upper = true;
            getFolderData();
        };

        function getFolderData(){
            $('#fileBrowserContainer').html('Loading...');

            $http({
                url: 'http://localhost:82/api/Files/Get',
                method: "GET",
                params: {currentPath: $scope.browser.path, folderName: $scope.browser.folder, toUpper: $scope.browser.upper}
            })
                .success(function(data){
                    $scope.browser.folderData=data;

                    $scope.browser.path = $scope.browser.folderData.CurrentPath;
                    $scope.browser.folder = '';
                    $scope.browser.upper = false;

                    var compiledHTML = $compile('<div file-browser-container></div>')($scope);
                    $('#fileBrowserContainer').html(compiledHTML);
                })
                .error(function(data){
                    alert("Api Request ERROR");
                });
        }
    }]);

    angular.module('fileBrowserApp').directive('fileBrowserContainer', function() {
        return {
            templateUrl: 'App/FileBrowser/Templates/file-browser-container.html'
        };
    });
})();