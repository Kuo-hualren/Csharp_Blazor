window.loadQrScript = function () {
    const script = document.createElement('script');
    script.src = './ScannerScript/qrScript.js';
    document.body.appendChild(script);
};

window.startQrScanner = function () {
    const html5Qrcode = new Html5Qrcode('reader');
    const qrCodeSuccessCallback = (decodedText, decodedResult) => {
        if (decodedText) {
            document.getElementById('show').style.display = 'block';
            document.getElementById('result').textContent = decodedText;
            document.getElementById('result').style.display = 'none';
            html5Qrcode.stop();
        }
    };
    const config = { fps: 10, qrbox: { width: 250, height: 250 } };
    html5Qrcode.start({ facingMode: 'environment' }, config, qrCodeSuccessCallback);
};

window.GetValue = function () {
    const inputField = document.getElementById('result').textContent;
    console.log(inputField);
    return inputField.value;
}

