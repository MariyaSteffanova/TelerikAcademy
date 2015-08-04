/* globals $ */

function solve() {
  
  return function (selector) {

    var defaultURL = "http://cdn.playbuzz.com/cdn/3170bee8-985c-47bc-bbb5-2bcb41e85fe9/d8aa4750-deef-44ac-83a1-f2b5e6ee029a.jpg";

    var  template = '';

    template+='<div class="container">';
    template+='<h1>Animals</h1>';
    template+='<ul class="animals-list">';

    template+='{{#animals}}';
    template+='<li>';
    template+='<a href="{{#if this.url}}{{this.url}}{{else}}'+ defaultURL+'{{/if}}">';
    template+='{{#if this.url}}See a {{this.name}}{{else}}No link for {{this.name}} , here is Batman!{{/if}}';
    template+='</a>';
    template+='</li>';
    template+='{{/animals}}';

    template+='</ul>';
    template+='</div>';

    $(selector).html(template);   
  };
};

module.exports = solve;