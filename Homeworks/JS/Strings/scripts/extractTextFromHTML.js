function extractText(){
    var html = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
    var text = html.replace(/<[a-z/]*>/g, '');

    document.getElementById('result-task6').textContent = text;
}