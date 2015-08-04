function solve() {

    return function (selector) {

        var template = '';

        template += '<table class="items-table">';

        template += '<thead><tr>';
        template += '<th>#</th>';
        template += '{{#headers}} <th>{{this}}</th> {{/headers}}'; // Important: with each the lenght of 'td's is 0 !!
        template += '</tr></thead>';

        template += '<tbody>';
        template += '{{#items}}<tr><td>{{@index}}</td>';
        template += '<td>{{col1}}</td>';
        template += '<td>{{col2}}</td>';
        template += '<td>{{col3}}</td>';
        template += '</tr>{{/items}}';
        template == '</tbody>';

        template += '</table>';

        $(selector).html(template);
    };
};
module.exports = solve;