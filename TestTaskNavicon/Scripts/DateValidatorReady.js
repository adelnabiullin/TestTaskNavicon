$(function () {
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || Globalize.parseDate(value, "dd.MM.yyyy", "ru");
    }
});