window.htmlToImage = {
  download: async function (elementId, filename, format = "image/png") {
    let element = document.getElementById(elementId);
    if (!element) {
      return;
    }

    const canvas = await html2canvas(element, { backgroundColor: null });
    const dataUrl = canvas.toDataURL(format, 1.0);

    const link = document.createElement("a");
    link.href = dataUrl;
    link.download = filename || `download.${format.split("/")[1]}`;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
};
