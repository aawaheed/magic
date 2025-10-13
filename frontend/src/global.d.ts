declare global {
  interface Window {
    ainiro: {
      $?: (selector: string) => Element | null;
      $$?: (selector: string) => element[];
      $id?: (id: string) => HTMLElement | null;
      [key: string]: any;
    };
  }
}
export {};
