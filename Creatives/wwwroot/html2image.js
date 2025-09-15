window.htmlToImage = {
  download: async function (elementId, filename) {
    let element = document.getElementById(elementId);
    if (!element) {
      return;
    }

    const canvas = await html2canvas(element, { backgroundColor: null });
    const dataUrl = canvas.toDataURL("image/png");

    const link = document.createElement("a");
    link.href = dataUrl;
    link.download = filename || "download.png";
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
};
