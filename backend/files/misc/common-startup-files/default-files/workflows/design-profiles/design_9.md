# Design System: Professional Staffing & HR Recruitment

## 1. Visual Theme & Atmosphere
The interface is a **"Corporate Midnight"** professional landing page, blending high-authority deep tones with vibrant "Action Red" highlights. The atmosphere is structured, trustworthy, and high-energy, moving away from the "Lavender Cloud" lightness toward a dense, premium dark-mode aesthetic. It utilizes geometric sharp-meets-soft edges and circular motifs to balance corporate rigidity with modern fluidity.

**Key Characteristics:**
* **Deep Gradient Canvas:** A rich, dark navy-to-charcoal background provides a high-contrast stage for bright text and crimson accents.
* **Circular Graphic Motifs:** Use of dotted circles and orbital lines behind human subjects to suggest "global reach" and "networking."
* **Structured Pricing Tiers:** Clean, vertical columns with high-contrast toggle switches for billing cycles.
* **Corporate Realism:** Photography features professionals in formal attire (suits) to emphasize high-level placement and staffing expertise.

## 2. Color Palette & Roles
### Core Neutrals
* **Midnight Navy (#0a0b2e):** `--palette-bg-primary`, the dominant background color for a premium, stable feel.
* **Pure White (#ffffff):** `--palette-text-primary`, used for major headlines and high-readability body copy.
* **Cool Slate (#94a3b8):** `--palette-text-secondary`, used for sub-labels and small metadata.
* **Deep Indigo-Grey (#1e1b4b):** `--palette-bg-card`, used for card backgrounds to create subtle elevation against the navy.

### Primary Accents
* **Electric Crimson (#ff2d55):** `--palette-bg-cta`, used for "Get Started" buttons and key action points.
* **Vibrant Rose-Red (#e11d48):** `--palette-bg-accent`, used for small badges (e.g., "Our Service") and "Read More" links.

## 3. Typography Rules
### Font Family
* **Primary:** **Outfit** or **Lexend** (Geometric Sans-Serif) for a clean, modern, and highly legible corporate look.
* **Secondary:** **Inter** for dense data, pricing tables, and footer links.

### Hierarchy
| Role | Font Size | Weight | Line Height | Notes |
| :--- | :--- | :--- | :--- | :--- |
| **Hero Headline** | 56px | 700 | 1.1 | Tight tracking, high impact |
| **Section Header** | 36px | 700 | 1.2 | Used for "Affordable Staffing" |
| **Card Title** | 20px | 600 | 1.4 | Module-based bold titles |
| **Pricing Dollar** | 42px | 800 | 1.0 | High-contrast white on dark |
| **Body Copy** | 16px | 400 | 1.6 | High-readability slate grey |

## 4. Component Stylings
* **Buttons:** Rectangular with a very small radius (4px–6px) rather than full pills. Includes a subtle chevron (>) icon for directional momentum.
* **Pricing Cards:** Distinct vertical blocks with a "Top-Heavy" weight—bold price at the top, followed by a list of features with checkmark icons.
* **Service Icons:** Circular containers with thin-line (2px) stroke icons in red/pink to break the text density.

## 5. Layout Principles
* **Z-Pattern Hero:** Text on the left, high-quality human imagery on the right, anchored by a dual-CTA button layout.
* **Standardized Grid:** Unlike the "Bento" style, this uses a more traditional 3-column service grid and 3-column blog grid for a sense of reliability and order.
* **Content "Islands":** Large sections are separated by significant vertical whitespace (120px+) to allow the brand story to breathe.

## 6. Depth & Elevation
| Level | Treatment | Use |
| :--- | :--- | :--- |
| **Level 0** | Solid Midnight | Primary background and footer |
| **Level 1** | Indigo Fill (#1e1b4b) | Service cards and blog thumbnails |
| **Level 2** | Border Stroke (1px White) | Hover states for pricing modules |

## 7. Do's and Don'ts
### Do
* Use red accents **only** for actionable elements or important category tags.
* Ensure all photography features professionals in high-contrast environments.
* Maintain a 1.6x line height for body text to keep the dark mode readable.
### Don't
* Don't use pastel colors; they will wash out against the dark navy background.
* Don't use large radius/pill shapes (keep it under 8px) to maintain a "serious" tone.
* Don't clutter the hero image; use "Cut-out" subjects (PNGs) to overlap background elements.

## 8. Responsive Behavior
* **Desktop:** 3-column pricing and service grids with a wide horizontal hero (Text-Left / Image-Right).
* **Tablet:** Hero image scales down and moves below the headline; pricing cards transition to a 2-column grid with the third card spanning full-width.
* **Mobile:** Strict single-column stack. The navigation menu collapses into a "Hamburger" icon. Hero imagery is often centered or simplified to a "headshot" only to preserve vertical space.

## 9. Agent Prompt Guide
**Quick Color Reference**
* **Background:** #0a0b2e
* **Primary Text:** #ffffff
* **CTA Red:** #ff2d55
* **Secondary Text:** #94a3b8

**Example Component Prompts**
* "Design a corporate hero: 56px bold white headline 'Growth Exceptional...', a cut-out photo of two smiling professionals on the right, and a vibrant red 'Get Started' button."
* "Create a pricing card: Deep navy background (#1e1b4b), white $259/mo text, and a clean list of features with checkmark icons."
* "Build a service module: A circular red stroke icon, 20px bold headline, and a small red 'Read More' link with a chevron icon."
* "Design a corporate footer: 4-column layout, dark background, including a centered subscription box and social media icons in white."

**Iteration Guide**
1.  Establish the **Midnight Navy** canvas first to ensure high-contrast accessibility.
2.  Use **Geometric Sans-Serif** (Outfit/Lexend) to bridge the gap between "Tech" and "Corporate."
3.  Apply the **Electric Crimson** sparingly; it should act as a "heat map" for where the user should click.
4.  Ensure **Vertical Rhythm**—maintain generous, consistent spacing (120px) between major sections to avoid a "cramped" feel.

---

### Additional Upgrade Suggestions & Questions

1.  **Motion Design:** Should we implement a **"Parallax Floating Effect"** for the circular graphic motifs behind the hero subjects to add a sense of depth as the user scrolls?
2.  **Social Proof Expansion:** Would you like to add a **"Client Success Story" carousel** right below the hero section to build immediate trust through video or text testimonials?
3.  **Data Visualization:** Should the "Latest Trends" blog section include **"Estimated Read Time" badges** in the accent red to encourage higher click-through rates?
4.  **Sticky Action:** How about a **"Quick Apply" floating button** that stays visible on mobile, allowing candidates to upload a resume at any point during their scroll?
5.  **Color Accessibility:** Should we test a **"High Contrast" mode** for the slate-colored body text to ensure it meets WCAG AAA standards against the dark navy background?