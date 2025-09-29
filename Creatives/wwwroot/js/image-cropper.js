window.cropperInterop = {
  cropperInstance: null,

  initializeCropper: function (imageElementId) {
    const image = document.getElementById(imageElementId);
    if (!image) return;

    this.cropperInstance = new Cropper(image, {
      aspectRatio: 1,
      viewMode: 1,
      movable: true,
      zoomable: true,
      scalable: false,
      rotatable: false,
      responsive: true,
      background: false
    });
  },

  getCroppedImageBase64: function () {
    if (!this.cropperInstance) return null;

    const canvas = this.cropperInstance.getCroppedCanvas({
      width: 300,
      height: 300,
      imageSmoothingQuality: 'high'
    });

    return canvas.toDataURL('image/png');
  },

  destroyCropper: function () {
    if (this.cropperInstance) {
      this.cropperInstance.destroy();
      this.cropperInstance = null;
    }
  }
};
