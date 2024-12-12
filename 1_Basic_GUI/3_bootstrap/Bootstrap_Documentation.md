
# **Bootstrap Documentation**

## **Introduction**

Bootstrap is a powerful, open-source front-end framework for building responsive, mobile-first websites and web applications. It provides a collection of reusable components, responsive grid systems, utility classes, and JavaScript plugins. 

**Key Features:**
- Fully responsive layout.
- Supports modern browsers.
- Pre-designed components like cards, tables, and forms.
- Comprehensive documentation.

**Getting Started:**
To include Bootstrap in your project, use the following CDN links:

**CSS:**
```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
```

**JavaScript:**
```html
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
```

---

## **Breakpoints**

Bootstrap provides responsive design capabilities using predefined breakpoints for various screen sizes:

| Breakpoint | Class Prefix | Min Width |
|------------|--------------|-----------|
| Extra Small (xs) | None       | `<576px` |
| Small (sm)        | `.sm`      | `≥576px` |
| Medium (md)       | `.md`      | `≥768px` |
| Large (lg)        | `.lg`      | `≥992px` |
| Extra Large (xl)  | `.xl`      | `≥1200px`|
| XXL               | `.xxl`     | `≥1400px`|

These breakpoints can be used with utility classes and components for responsive behavior.

---

## **Container**

The **container** is a fundamental layout element in Bootstrap used to center and horizontally pad your site content. It has three types:

### Example:
```html
<div class="container">Fixed-width container</div>
<div class="container-fluid">Full-width container</div>
<div class="container-md">Responsive container based on breakpoints</div>
```

- `.container`: Fixed-width layout.
- `.container-fluid`: Full-width, takes the entire screen width.
- `.container-{breakpoint}`: Responsive containers adjusting at specified breakpoints.

---

## **Grid System**

Bootstrap’s grid system is a 12-column layout that uses a combination of **rows** and **columns**. 

### Example:
```html
<div class="container">
  <div class="row">
    <div class="col">Column 1</div>
    <div class="col">Column 2</div>
    <div class="col">Column 3</div>
  </div>
</div>
```

**Classes:**
- `.row`: Groups columns.
- `.col`: Automatically resizes to fit equally.
- `.col-{breakpoint}-{size}`: Adjust size for specific breakpoints.

### Features:
- Nestable rows and columns.
- Responsive column sizes using breakpoints.

---

## **Table**

Bootstrap tables are styled for enhanced visual appearance and support responsive behavior.

### Example:
```html
<table class="table">
  <thead>
    <tr>
      <th>#</th>
      <th>Name</th>
      <th>Age</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>1</td>
      <td>John</td>
      <td>25</td>
    </tr>
  </tbody>
</table>
```

**Classes:**
- `.table-striped`: Adds zebra-striping.
- `.table-bordered`: Adds borders.
- `.table-hover`: Adds hover effect.
- `.table-responsive`: Makes table scrollable on smaller devices.

---

## **Card**

Cards are flexible content containers with multiple variants for layout and style.

### Example:
```html
<div class="card" style="width: 18rem;">
  <img src="image.jpg" class="card-img-top" alt="Image">
  <div class="card-body">
    <h5 class="card-title">Card Title</h5>
    <p class="card-text">Some quick example text.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
```

**Features:**
- Supports images, headers, and footers.
- Combine with utility classes for custom styling.

---

## **Form**

Forms in Bootstrap come with various styles and controls.

### Example:
```html
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

**Classes:**
- `.form-control`: Styles input fields.
- `.form-label`: Styles labels.
- `.form-check`: Styles checkboxes and radios.

---

## **Utility Classes**

Bootstrap includes a variety of utility classes for quick styling:

### Spacing:
```html
<div class="m-3 p-3">Margin and Padding</div>
```

### Text:
- `.text-center`: Centers text.
- `.text-muted`: Muted text.

### Background:
- `.bg-primary`: Blue background.
- `.bg-light`: Light background.

### Display:
- `.d-none`: Hide an element.
- `.d-flex`: Apply flexbox.

For a complete list of utilities, refer to the official [Bootstrap Documentation](https://getbootstrap.com/).
