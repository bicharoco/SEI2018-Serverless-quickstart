
(function () {
    'use strict';

    angular.module('sei2018app')
        .controller('MainController', function ($scope, $http, adalAuthenticationService) {
            let _baseApiAddress = window.location.hostname == 'localhost'
                                ? 'http://localhost:7071/'
                                : 'https://sei-2018-main-function.azurewebsites.net/';

            let _baseNoteAddress = _baseApiAddress + 'api/note/';

            $scope.notesList = null;
            
            var _getNotes = () => {
                $scope.notesList = null;

                return $http.get(_baseNoteAddress).then((response) => {
                    $scope.notesList = response.data;
                });
            };
            $scope.getNotes = _getNotes;
            _getNotes();

            $scope.submitingNewNote = false;
            $scope.addNewNote = (newNote) => {
                $scope.submitingNewNote = true;

                $http.post(_baseNoteAddress, newNote).then((response) => {
                    $scope.newNote = null;

                    _getNotes().then(() => $scope.submitingNewNote = false);
                }, () => $scope.submitingNewNote = false);
            };

            $scope.editNote = (noteToEdit) => {
                $scope.submitingNoteToEdit = true;

                $http.put(_baseNoteAddress + noteToEdit.id, noteToEdit).then((response) => {
                    $scope.noteToEdit = null;

                    $('#myModal').modal('hide');
                    $scope.submitingNoteToEdit = false;
                    
                    _getNotes();
                }, () => {
                    $scope.submitingNoteToEdit = false;
                    $('#myModal').modal('hide');
                });
            };

            $scope.openEditModal = (noteToEdit) => {
                $scope.noteToEdit = angular.copy(noteToEdit);
                $('#myModal').modal('show');
            };

            $scope.deleteNote = (noteToDelete) => $http.delete(_baseNoteAddress + noteToDelete.id).then((response) => _getNotes());

            $scope.logout = () => adalAuthenticationService.logout();
        });
})();