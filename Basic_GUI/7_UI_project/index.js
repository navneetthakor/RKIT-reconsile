// for mainContainer
// -> when user click on buttons
$('button[type="submit"]').click(function (event) {
  // preventing form to submit
  event.preventDefault();

  // check if username is provided or not
  const username = $("input[type='text']").val();
  if (!username) {
    alert("enter username first");
    return;
  }

  // enabling loader
  $("#loadingContainer").toggleClass("d-none");
  $("#mainContainer").toggleClass("d-none");

  if ($(this).text().trim() === "Github") {
    $.get(`https://api.github.com/users/${username}`, function (data, status) {
      // removing loader
      $("#loadingContainer").addClass("d-none");
      $("#githubContainer").removeClass("d-none");

      console.log(data);
      // setting profile image
      $("#avtar > img").attr("src", data.avatar_url);

      // github stats
      const spans = $("#githubStats button > span");
      console.log(spans);
      spans.first().text(data.followers);
      spans.eq(1).text(data.following);
      spans.last().text(data.public_repos);

      // setting name
      $("#avtar").next().text(data.name);

      // setting bio
      const bio = data.bio ? data.bio : "Bio not available";
      $(".bio").text(bio);

      $(".gitBtns > a").attr("href", data.html_url);
    });
  }
});

$("#gcCloser").click(function (event) {
  $("#loadingContainer").addClass("d-none");
  $("#mainContainer").removeClass("d-none");
  $("#githubContainer").addClass("d-none");
});
