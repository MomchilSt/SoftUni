  
import { Component, OnInit } from '@angular/core';
import {Article} from '../models/article.model';
import {Input} from '@angular/core';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  private symbols = 250;
  @Input() article: Article;
  @Input() articleDescr: string;
  descToShow: string;
  articleDescLen: number;
  showReadMoreBtn = true;
  showHideBtn = false;
  imageIsShown = false;
  imageBtnTitle = 'Show Image';

  constructor() {
    this.articleDescLen = 0;
    this.descToShow = '';
  }

  ngOnInit() {
  }

  readMore(): void {
    this.articleDescLen += this.symbols;
    // tslint:disable-next-line:no-conditional-assignment
    if (this.articleDescLen >= this.articleDescr.length) {
      this.showHideBtn = true;
      this.showReadMoreBtn = false;
      this.descToShow = this.article.description;
    } else {
      this.descToShow = this.articleDescr.substring(0, this.articleDescLen);
    }
  }

  toggleImage(): void{
    this.imageIsShown = !this.imageIsShown;
    // @ts-ignore
    this.imageBtnTitle = this.imageBtnTitle === 'Show Image'
    ? 'Hide Image' : 'Show Image';
  }

  hideDesc(): void {
    this.descToShow = '';
    this.articleDescLen = 0;
    this.showHideBtn = false;
    this.showReadMoreBtn = true;
  }
}