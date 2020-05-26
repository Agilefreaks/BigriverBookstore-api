class V1::BooksController < ApplicationController
  def index
    @pagy, books = pagy(Book.all)
    render json: BookSerializer.new(books).serialized_json
  end

  def show
    book = Book.find(params[:id])
    render json: BookSerializer.new(book).serialized_json
  end
end
