var handleChange = function () {
	var e = document.querySelector("#input-file").files;
	if (0 !== e.length) {
		var o = e[0];
		readFile(o)
	}
},
	readFile = function (e) {
		if (e) {
			var o = new FileReader;
			o.onload = function () {
				document.querySelector(".preview-box").innerHTML = '<img class="preview-content" src=${reader.result} />'
			}, o.readAsDataURL(e)
		}
	},
	uppy = Uppy.Core().use(Uppy.Dashboard, {
		inline: !0,
		target: "#drag-drop-area"
	}).use(Uppy.Tus, {
		endpoint: "https://google.com"
	});
uppy.on("complete", function (e) {
	console.log("Upload complete! We’ve uploaded these files:", e.successful)
});